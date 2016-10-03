using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.Content;

namespace GitLab_Clone.Droid.Adapters
{
    class GitProjectListAdapter : BaseAdapter
    {
        private List<GitProject> gitProjectList;
        private LayoutInflater layoutInflator;

        public GitProjectListAdapter(Context context, List<GitProject> gitProjectList)
        {
            this.gitProjectList = gitProjectList;
            layoutInflator = LayoutInflater.From(context);
        }

        public override int Count
        {
            get { return gitProjectList.Count;  }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView ?? layoutInflator.Inflate(Resource.Layout.ViewGitProjectList, parent, false);
            var firstLine = view.FindViewById<TextView>(Resource.Id.FirstLine);
            var secondLine = view.FindViewById<TextView>(Resource.Id.SecondLine);

            firstLine.Text = gitProjectList[position].name;
            secondLine.Text = gitProjectList[position].http_url_to_repo;

            return view;
        }
    }
}