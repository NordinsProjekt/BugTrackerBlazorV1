using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace BugTrackerUI.Pages
{
    public partial class ProjectBugs
    {
        [Parameter]
        public int Id { get; set; }

        public List<Bug> Bugs { get; set; }
        protected List<Bug> TestData()
        {
            Data db = new Data();
            Bugs = db.GetBugs().Where(x => x.ProjectId == Id).OrderBy(x => x.Priority).ToList();
            return Bugs;
        }
    }
}
