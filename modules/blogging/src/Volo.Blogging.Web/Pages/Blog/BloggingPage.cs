using System;
using System.Text;
using System.Text.RegularExpressions;
using CommonMark;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Blogging.Localization;

namespace Volo.Blogging.Pages.Blog
{
    public abstract class BloggingPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<BloggingResource> L { get; set; }

        public const string DefaultTitle = "Blog";

        public const int MaxShortContentLength = 128;

        public string GetTitle(string title = null)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return DefaultTitle;
            }

            return title;
        }

        public string GetPreviewOfContent(string content) //TODO: This should be moved to its own place!
        {
            var html = RenderMarkDownToHtmlAsString(content);

            var paragraphs = Regex.Matches(html, "<p>(.*?)</p>", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            var firstParagraph = paragraphs.Count <= 0 ? html : paragraphs[0].Groups[1].Value;

            return string.IsNullOrEmpty(firstParagraph) ?
                string.Empty :
                firstParagraph.TruncateWithPostfix(MaxShortContentLength, "...");
        }

        public IHtmlContent RenderMarkdownToHtml(string markdown)
        {
            return new HtmlString(RenderMarkDownToHtmlAsString(markdown));
        }

        public string RenderMarkdownToString(string content)
        {
            byte[] bytes = Encoding.Default.GetBytes(content);
            var utf8Content = Encoding.UTF8.GetString(bytes);

            return CommonMarkConverter.Convert(utf8Content);
        }

        public LocalizedHtmlString ConvertDatetimeToTimeAgo(DateTime dt)
        {
            var timeDiff = DateTime.Now - dt;

            var diffInDays = (int)timeDiff.TotalDays;

            if (diffInDays >= 365)
            {
                return L["YearsAgo", diffInDays / 365];
            }
            if (diffInDays >= 30)
            {
                return L["MonthsAgo", diffInDays / 30];
            }
            if (diffInDays >= 7)
            {
                return L["WeeksAgo", diffInDays / 7];
            }
            if (diffInDays >= 1)
            {
                return L["DaysAgo", diffInDays];
            }

            var diffInSeconds = (int)timeDiff.TotalSeconds;

            if (diffInSeconds >= 3600)
            {
                return L["HoursAgo", diffInSeconds / 3600];
            }
            if (diffInSeconds >= 60)
            {
                return L["MinutesAgo", diffInSeconds / 60];
            }
            if (diffInSeconds >= 1)
            {
                return L["SecondsAgo", diffInSeconds];
            }

            return L["Now"];
        }

        private static string RenderMarkDownToHtmlAsString(string markdown)
        {
            if (string.IsNullOrWhiteSpace(markdown))
            {
                return string.Empty;
            }

            byte[] bytes = Encoding.Default.GetBytes(markdown);
            var utf8Content = Encoding.UTF8.GetString(bytes);

            return CommonMarkConverter.Convert(utf8Content);
        }
    }
}
