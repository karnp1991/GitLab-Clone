using System;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GitLab_Clone.Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        GetGitProjectsListFromServer gitProject;
        public MainPage()
        {
            this.InitializeComponent();
            gitProject = new GetGitProjectsListFromServer();
            gitProject.ThresholdReached += gitProject_ThresholdReached;
        }

        void gitProject_ThresholdReached(Object sender, ThresholdReachedEventArgs e)
        {
            if (e.gitProjectList != null)
            {
                ProjectList.ItemsSource = e.gitProjectList;
            }
        }
    }
}
