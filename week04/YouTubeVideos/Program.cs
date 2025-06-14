using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store videos
            List<Video> videos = new List<Video>();

            // Create first video
            Video video1 = new Video("How to Make Perfect Pancakes", "Chef John", 600);
            video1.AddComment(new Comment("Sarah", "These pancakes look amazing! Can't wait to try the recipe."));
            video1.AddComment(new Comment("Mike", "I've made these twice now and they're perfect every time!"));
            video1.AddComment(new Comment("Emma", "What kind of flour do you recommend?"));
            videos.Add(video1);

            // Create second video
            Video video2 = new Video("10-Minute Morning Workout", "FitnessPro", 600);
            video2.AddComment(new Comment("John", "This workout really gets my day started right!"));
            video2.AddComment(new Comment("Lisa", "Perfect for busy mornings, thank you!"));
            video2.AddComment(new Comment("David", "Can I do this workout every day?"));
            video2.AddComment(new Comment("Anna", "The music is great too!"));
            videos.Add(video2);

            // Create third video
            Video video3 = new Video("Python for Beginners", "CodeMaster", 1800);
            video3.AddComment(new Comment("Alex", "Finally, a tutorial that makes sense!"));
            video3.AddComment(new Comment("Sophie", "Could you make more videos about data structures?"));
            video3.AddComment(new Comment("Ryan", "This helped me pass my programming class!"));
            videos.Add(video3);

            // Display information for each video
            foreach (Video video in videos)
            {
                Console.WriteLine($"\nTitle: {video.GetTitle()}");
                Console.WriteLine($"Author: {video.GetAuthor()}");
                Console.WriteLine($"Length: {video.GetLength()} seconds");
                Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
                Console.WriteLine("Comments:");
                
                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetCommentText()}");
                }
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}