using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Http;
using Xunit;

namespace Volo.Abp.AspNetCore.Mvc.Validation
{
    public class FluentValidationTestController_Tests : AspNetCoreMvcTestBase
    {
        [Fact]
        public async Task Should_Validate_Object_Result_Success()
        {
            var result = await GetResponseAsStringAsync("/api/fluent-validation-test/object-result-action?value1=hello");
            result.ShouldBe("hello");
        }

        [Fact]
        public async Task Should_Validate_Object_Result_Failing()
        {
            //value1 has min length of 2 chars.
            var result = await GetResponseAsObjectAsync<RemoteServiceErrorResponse>("/api/fluent-validation-test/object-result-action?value1=0", HttpStatusCode.BadRequest); 
            result.Error.ValidationErrors.Length.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Validate_Nesting_Object_Result_Failing()
        {
            //value1 & InnerValue1 has min length of 2 chars.
            var result = await GetResponseAsObjectAsync<RemoteServiceErrorResponse>("/api/fluent-validation-test/object-result-action2?value1=0", HttpStatusCode.BadRequest); 
            result.Error.ValidationErrors.Length.ShouldBe(2);
        }

        [Fact]
        public async Task Should_Not_Validate_Action_Result_Success()
        {
            var result = await GetResponseAsStringAsync("/api/fluent-validation-test/action-result-action?value1=hello");
            result.ShouldBe("ModelState.IsValid: true");
        }

        [Fact]
        public async Task Should_Not_Validate_Action_Result_Failing()
        {
            var result = await GetResponseAsStringAsync("/api/fluent-validation-test/action-result-action"); //Missed the value1
            result.ShouldBe("ModelState.IsValid: false");
        }
    }
}
