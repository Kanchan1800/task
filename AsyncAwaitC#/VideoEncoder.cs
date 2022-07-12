
// See https://aka.ms/new-console-template for more information


public class VideoEventArgs:EventArgs{

    public Video Video { get; set; }
}
public class VideoEncoder
{
    //1.define a delegate-signature of method in the subscriber
    //2.deifne an event based on that delegate
    //3.raise the event

    //public delegate void VideoEncodedEventHandler(object source,VideoEventArgs args); --1
    //public event VideoEncodedEventHandler VideoEncoded; --2
    //EventHandler
    //EventHandler <TEventArgs>

    public event EventHandler<VideoEventArgs> VideoEncoded;//replacement for line 1 & 2
    
    

    protected virtual void OnVideoEncoded(Video video)
    {
        if(VideoEncoded!=null)
        VideoEncoded(this,new VideoEventArgs(){Video= video});

    }

    public void Encode(Video video)
    {
        System.Console.WriteLine("encoding video...");
        Thread.Sleep(3000);
        OnVideoEncoded(video);
    }



    public event EventHandler<VideoEventArgs> VideoDeleted;
    protected virtual void OnVideoDeleted(Video video)
    {
        if(VideoDeleted!=null)
        VideoDeleted(this,new VideoEventArgs(){Video =video});
    }

    public void Delete(Video video)
    {
        System.Console.WriteLine("deleting video...");
        Thread.Sleep(3000);
        OnVideoDeleted(video);
    }
}