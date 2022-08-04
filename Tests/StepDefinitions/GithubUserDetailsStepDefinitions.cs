using API.Controllers.Github.Users;
using API.Models.Github.Responses;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Tests.StepDefinitions
{
    [Binding]
    public class GithubUserDetailsStepDefinitions
    {
        internal IUsersApi _usersApi;
        private UserDetailsResponse _userDetails = null;

        public GithubUserDetailsStepDefinitions(IUsersApi usersApi)
        {
            _usersApi = usersApi;
        }

        [Given(@"I have path /'([^']*)'")]
        public void GivenIHavePath(string path)
        {
            Console.WriteLine($"I make a request to /{path}");
        }

        [Given(@"I have username '([^']*)'")]
        public void GivenIHaveUsername(string userName)
        {
            Console.WriteLine($"And try to get details for {userName}");
        }

        [When(@"I trgigger API endpoint for given user '([^']*)'")]
        public async void WhenITrgiggerAPIEndpointForGivenUser(string userName)
        {
            _userDetails = await _usersApi.GetUserDetails(userName);
        }

        [Then(@"I get full details including '([^']*)' and '([^']*)'")]
        public void ThenIGetFullDetailsIncludingAnd(string type, string createDate)
        {
            Assert.AreEqual(type.ToLower(), _userDetails.type.ToLower());
            Assert.AreEqual(createDate, _userDetails.created_at.ToString());
        }
    }
}
