using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Video Monitoring Tracker program!");
        Console.WriteLine("Here we provide the video information to be analyzed");
        Console.WriteLine();
        List<Video> videos = new List<Video>();

        Video video = new Video("Why Prayer Helps With Anger", "The Church of Jesus Christ of Latter-day Saints", 1560);
        video.AddComment(new Comment("@daineclark", "Have to admit as I first was listening I was thinking, “my wife needs to see this” but after watching the whole thing I’m realizing it’s me that needed to see this. Thanks for being vulnerable and sharing to inspire us all. 😊"));
        video.AddComment(new Comment("@KellHerman", "I have struggled with my temper for as long as I can remember. I’ve made big strides, but now as I take on new challenges, old anger habits seem to resurface. I noticed that the more angry and frustrated I become, the more I naturally turn inward and the less I pray. Thank you for sharing your journey, I really really need this and I feel humbled by it. I love how Jesus prayed more earnestly when He was in agony. I will try to be like Him in that way ❤"));
        video.AddComment(new Comment("@Sidehustlergeek", "Starting today, I'm beginning my 30-Day cleanse from anger, My children need this, My wife needs this, I need this! Through Christ, I can be clean!"));
        videos.Add(video);

        Video video1 = new Video("Finding Beauty in the Storm: Our Journey Through Infertility and Faith", "@churchofjesuschrist", 300);
        video1.AddComment(new Comment("@xenithix1337", "These are the videos that drive God fearing men and women from the light. I will pray for you, in Christ's holy name we pray, Amen"));
        video1.AddComment(new Comment("@lukedav", "True peace and rest truly do come from Christ, I know this with my whole heart! ❤️"));
        video1.AddComment(new Comment("@melaniemilby8115", "I love the power of this beautiful truth and the way it is being expressed through amazing art"));
        videos.Add(video1);


        Video video2 = new Video("John 8 | Go and Sin No More | The Bible", "The Church of Jesus Christ of Latter-day Saints", 600);
        video2.AddComment(new Comment("PeterLassig", "Neither do I condemn thee\"... Oh how I love the beauty of Jesus' words."));
        video2.AddComment(new Comment("cruzdaily229", "Jesus Christ is my hero ☝🏻 The only one to whom I bow 👑 ✝️"));
        video2.AddComment(new Comment("hvneyr5773", "Jesus is the only person that can give you peace not this world, betrayal from the ones close to me, so much sickness put on me. But I called on to Jesus and he healed me even despite all the sinning I was doing. Please repent, he loves us so much words can’t even explain. He Laid his one and only son on the cross for us. Don’t love this world love Jesus."));
        videos.Add(video2);


        Video video4 = new Video("Game Development Tips", "GameDevGuru", 180);
        video4.AddComment(new Comment("GameDevMaster", "This is gold!"));
        video4.AddComment(new Comment("GamingFanatic", "So useful, thanks!"));
        video4.AddComment(new Comment("IndieDev", "Really appreciate this content!"));
        videos.Add(video4);

        foreach (var i in videos)
        {
            Console.WriteLine(i.GetInfo());
            Console.WriteLine();
            Console.WriteLine($"Number of Comments: {i.GetNumberOfComments()}");
            foreach (var comment in i.GetComments())
            {
                Console.WriteLine(comment.GetInfo());
            }
            Console.WriteLine();
        }   
    }
}

