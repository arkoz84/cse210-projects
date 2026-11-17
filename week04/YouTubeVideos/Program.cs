using System;

class Program
{
    static void Main(string[] args)
    {
        Video firstVideo = new Video("Learn C# BASICS in 10 MINUTES!", "Code Monkey", 654);
        firstVideo.AddComment(new Comment("@Noel-jk", "watching at 2x speed, I lerned c# in just 5 minuts, efficency"));
        firstVideo.AddComment(new Comment("@ExpatRealityCheck", "For a complete beginner, this will go over their head. But after spending some time in a beginner's course and learning code, this is basically a solid cheat sheet and/or solid summary review."));
        firstVideo.AddComment(new Comment("@akc_cs", "Yes,  we want this type of video but in more deep, with basic then advance"));

        Video secondVideo = new Video("What is C#? [Pt 1] | C# for Beginners", "dotnet", 102);
        secondVideo.AddComment(new Comment("@Michael-lo3ht", "Finally! I love the fact you speak clear, fluent, and the right speed.  It's nice when you're trying to take in something technical you're not fighting to understand the person.  Straightforward enough for anyone.  Thanks a million."));
        secondVideo.AddComment(new Comment("@me_lvin7068", "I just finished watching and coding along with your older C# Tutorial for Beginners video with Scott and Kendra, and this is a breath of fresh air. 🎉 Thanks."));
        secondVideo.AddComment(new Comment("@brianschmit7757", "Scott Hanselman was in my senior class at OIT in 2004. We both had Farjami for Statistics 405"));

        Video thirdVideo = new Video("Learn C# Sharp in Four Minutes", "Programming w/ Professor Sluiter", 249);
        thirdVideo.AddComment(new Comment("@thebeatsenpai2357", "I watched in 2 x speed. I became a C# developer in 2 minutes."));
        thirdVideo.AddComment(new Comment("@mask4037", "Thanks got a job 60k year in 4mins 30sec learning"));
        thirdVideo.AddComment(new Comment("@markoth5678", "Its like telling me how Spanish was made and saying now you know Spanish"));

        List<Video> videos = new List<Video> { firstVideo, secondVideo, thirdVideo };

        foreach (Video video in videos)
        {
            Console.WriteLine(video.GetDisplayText());
            Console.WriteLine($"Comments: {video.GetCommentCount()}");
            video.DisplayComments();
            Console.WriteLine();
        }
    }
}