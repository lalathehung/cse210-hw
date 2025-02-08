public class VideoLibrary {

    private Video video1;
    private Video video2;
    private Video video3;

    private List<Video> videoLibrary;

    //constructor
    public VideoLibrary(){

        video1 = new Video("12 Things You NEED To Know Before Law School", "Tex", "11:21");
        video2 = new Video("Campus in 2 Minutes | Get to Know BYU-Idaho", "BYU-Idaho", "2:02");
        video3 = new Video("Installing MySQL and Creating Databases | MySQL for Beginners", "Alex The Analyst", "12:04");

        video1.AddComment(new Comment("diarybysophiac", "I am really glad that I bumped into this video."));
        video1.AddComment(new Comment("jamieruiz2445", "This is really solidifying my decision to go to Law School,  Thank you so much."));
        video1.AddComment(new Comment("JPWick", "This is the REALEST feedback on law school. Big ups"));

        video2.AddComment(new Comment("konankouadio5509", "The best university."));
        video2.AddComment(new Comment("lalathehung", "So proud that I belongs to here!"));
        video2.AddComment(new Comment("yuetshung2", "Can I earn a degree from BYU-Idaho without coming to Rexburg?"));

        video3.AddComment(new Comment("Tebas321", "I just start the bootcamp and I got to say this is by far the most practical course that I found to learn MySQL, Thank you very much Alex."));
        video3.AddComment(new Comment("sols9019", "Lesson 1, Done! Excited to move to the next tutorial. Very handy with clear instructions Alex! Thankie!"));
        video3.AddComment(new Comment("desmondhenrymarfo2073", "I'm now beginning this SQL journey and I´m happy to be your student... Fully subscribed!"));

        videoLibrary = new List<Video>
        {
            video1,
            video2,
            video3,
        };
    }
    public string DisplayLibrary(){
            string result = "Videos\n";
            foreach(var video in videoLibrary){
                result += video.DisplayVideoInfo() + "\n";
            }
            return result;
        }
}