using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace RAGEMPTest.DiscordBot
{
    class DiscordBot
    {
        public static void sendMessageToDiscord(string color, string title, string msg)
        {
            string token = "PASTE YOUR TOKEN HERE!";
            // string exampleToken = "https://discord.com/api/webhooks/54846546531668217/1234329847123984184981698127649801701784";
            WebRequest wr = (HttpWebRequest)WebRequest.Create(token);

            wr.ContentType = "application/json";
            wr.Method = "POST";

            string discordEmbedColor = "2123412";
            // With "" - you keep the standard color (dark blue)
            if (color != "") {
                discordEmbedColor = color;
            }

            using (var sw = new StreamWriter(wr.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    username = "im beast.",
                    embeds = new[]
                    {
                        new
                        {
                            title = title,
                            description = msg,
                            color = discordEmbedColor
                        }
                    }
                });

                sw.Write(json);
                //Console.WriteLine($"Discord message sent.");
            }
            var response = (HttpWebResponse)wr.GetResponse();
        }
    }
}