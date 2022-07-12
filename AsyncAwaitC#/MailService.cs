// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// async Task ReadFile(){
//     await Task.Delay(150);
//     Console.WriteLine("Hello, World 2345!");
//     var lines= await File.ReadAllLinesAsync("file.txt");
//     foreach(var line in lines)
//     {
//         System.Console.WriteLine(line);
//     }
//     Console.WriteLine("Hello, World endsss!");


// }

// await ReadFile();

// Console.WriteLine("Hello, World2!");

// static async Task<int> GetDataFromNetwork(){
//     await Task.Delay(150);
//     var result=42;
//     return result;
// }
// var networkResult=await GetDataFromNetwork();
// System.Console.WriteLine(networkResult);

public class MailService{

    public void OnVideoEncoded(object source,VideoEventArgs e)
    {
        System.Console.WriteLine("MailService : Sending an email..." + e.Video.Title);
    }
     public void OnVideoDeleted(object source,VideoEventArgs e)
    {
        System.Console.WriteLine("MailService : Sending an email of video deleted..." + e.Video.Title);
    }
}
