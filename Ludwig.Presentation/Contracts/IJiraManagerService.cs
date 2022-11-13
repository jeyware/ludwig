using System.Collections.Generic;
using Ludwig.Presentation.Models;
using Microsoft.AspNetCore.Http;

namespace Ludwig.Presentation.Contracts
{
    public interface IJiraManagerService
    {


        List<JiraIssue> GetAllIssuesByUserStory(string storyName);

        IJiraManagerService UseContext(HttpContext context);
    }
}