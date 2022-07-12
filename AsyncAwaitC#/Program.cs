// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

async Task ReadFile(){
    await Task.Delay(150);
    Console.WriteLine("Hello, World 2345!");
    var lines= await File.ReadAllLinesAsync("file.txt");
    foreach(var line in lines)
    {
        System.Console.WriteLine(line);
    }
    Console.WriteLine("Hello, World endsss!");


}

await ReadFile();

Console.WriteLine("Hello, World2!");

static async Task<int> GetDataFromNetwork(){
    await Task.Delay(150);
    var result=42;
    return result;
}
var networkResult=await GetDataFromNetwork();
System.Console.WriteLine(networkResult);

/* event and delegates!!!!*/
/*PUBLISHER                                             SUBSCRIBER

-has an event                                         -can subscribe to an event of the publisher
how to initialise event in publisher?
public event EventHandler<VideoEventArgs> VideoEncoded;
How to raise this event?
protected virtual void OnVideoEncoded(Video video)    -in subscribers class same function is overloaded
                                                        public void OnVideoEncoded(object source,VideoEventArgs e)
                                                        they can subscribe to the event by writing
                                                        videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
                                                        videoencoded is the list of all pointers to subscribed class's method 


*/
// var video=new Video(){Title="Video 1"};
// var videoEncoder =new VideoEncoder();//publisher
// var mailService =new MailService();//subscriber
// var messageService =new MessageService();//subscriber
// videoEncoder.VideoEncoded += mailService.OnVideoEncoded; //list of reference or pointer to that method
// videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
// videoEncoder.Encode(video);

// videoEncoder.VideoDeleted+=mailService.OnVideoDeleted;
// videoEncoder.VideoDeleted+=messageService.OnVideoDeleted;
// videoEncoder.Delete(video);
