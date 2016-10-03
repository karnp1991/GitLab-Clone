using System;

using Android.App;
using Android.Widget;
using Android.OS;
using GitLab_Clone.Droid.Adapters;

namespace GitLab_Clone.Droid
{
	[Activity (Label = "GitLab_Clone.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;
        GetGitProjectsListFromServer gitProject;
        ListView listView;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button> (Resource.Id.myButton);

            //button.click += delegate {
            //	button.text = string.format ("{0} clicks!", count++);
            //};
            this.Title = "Git Clone";
            listView = FindViewById<ListView>(Resource.Id.ProjectListView);
            gitProject = new GetGitProjectsListFromServer();
            gitProject.ThresholdReached += gitProject_ThresholdReached;
        }

        void gitProject_ThresholdReached(Object sender, ThresholdReachedEventArgs e)
        {
            if (e.gitProjectList != null)
            {
                GitProjectListAdapter adapter = new GitProjectListAdapter(this, e.gitProjectList);
                //SimpleAdapter adapter = new SimpleAdapter(this, e.gitProjectList, Android.Resource.Layout.SimpleListItem2, new String[] {"First Line", "Second Line"}, new int[] {Android.Resource.Id.Text1, Android.Resource.Id.Text2});
                listView.Adapter = adapter;
            }
        }
    }
}


