using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailsPage : ContentPage
    {
        Post selectedPost;
        public PostDetailsPage(Post selectedPost)
        {
            InitializeComponent();

            this.selectedPost = selectedPost;
            experienceEntry.Text = selectedPost.Experience;
        }

        private void updateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience = experienceEntry.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedPost);
                conn.Close();

                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience successfully updated", "Okay");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to update", "Okay");
                }
            }
        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost);
                conn.Close();

                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience successfully deleted", "Okay");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to delete", "Okay");
                }
            }
        }
    }
}