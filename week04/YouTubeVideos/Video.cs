public class Video
{
    private string _title;
    private string _author;
    private string _length;
    private List<Comment> _commentsList = new List<Comment>();
    private Comment _thisComment;

    public void AddComment(Comment thisComment)
    {
        _commentsList.Add(thisComment);
    }

    public string DisplayCommentList()
    {
        string result = "";
        foreach (var comment in _commentsList)
        {
            
            result += $"{comment.GetDisplayText()}\n";
        }
        return result;
    }

    public Video(Comment thisComment, string title, string author, string length)
    {
        _thisComment = thisComment;
        _title = title;
        _author = author;
        _length = length;
    }

    public Video(string title, string author, string length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public string DisplayVideoInfo()
    {
        int numComments = _commentsList.Count;
        string videoInfo = $"\nVideo: {_title} \nBy {_author} {_length} minutes\n{numComments} comments\n";
        string comments = DisplayCommentList();

        return "\n----------------------------------\n" + videoInfo + "\n----------------------------------\n" + "\nComments:\n" + comments;
    }
}