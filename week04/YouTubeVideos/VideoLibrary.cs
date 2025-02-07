public class VideoLibrary {

    private Video video1;
    private Video video2;
    private Video video3;

    private List<Video> videoLibrary;

    //constructor
    public VideoLibrary(){

        video1 = new Video("Dogs are Cute", "DoggyDayz", "3:15");
        video2 = new Video("How to Eat Cheese", "IHeartCheese", "32:21");
        video3 = new Video("Best Books for Whale Lovers", "BookyBook", "1:07");

        video1.AddComment(new Comment("Silly Head", "Great video! It changed my life and now I'm a millionaire!!!"));
        video1.AddComment(new Comment("Meany Face", "Stupidest video ever! Till the day I die, I will never forget how much time I wasted watching this!!!"));
        video1.AddComment(new Comment("Timmy Taco", "Meh!!!"));

        video2.AddComment(new Comment("Gouda Goodman", "I still don't get it, please help!"));
        video2.AddComment(new Comment("Colby Jack", "But what about goat cheese?"));
        video2.AddComment(new Comment("Swissy Missy", "This is the hardest video I've ever had to follow. I still can't figure out how to eat cheese."));

        video3.AddComment(new Comment("Bob Bobster Bobington", "I am the biggest whale fan ever. Finally someone who understands me!!!"));
        video3.AddComment(new Comment("Herman Melville", "I don't know what I would have done without this inspiring list of books!"));
        video3.AddComment(new Comment("Blubbery Blubberson", "Not the most comprehensive list. You forgot all the other great whale books."));

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