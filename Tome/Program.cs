using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Tome
{
    class Program
    {

        private static readonly TelegramBotClient Bot = new TelegramBotClient("524003261:AAHXGt_GWBIkyphhrX6MPKXnuvQ4AyJ4ymI");
        public int penalidades = 0;
        static void Main(string[] args)
        {

            //string s = wit.Consulta("Que Horas são?");
            // wit.Consulta("Que Horas são?");

            //JsonConvert.PopulateObject(s,wit);

            //Console.WriteLine(wit.Entities.Intent[0].values);

            Bot.OnMessage += Bot_OnMessage;
            Bot.OnMessageEdited += Bot_OnMessage;

            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Wit wit = new Wit();
            Acoes acoes = new Acoes();

            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.TextMessage)
            {
                if (e.Message.Text.ToLower().Contains("bom dia"))
                {
                    switch (e.Message.From.FirstName)
                    {
                        case "Luan":
                            await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Bom dia Luan");
                            break;
                        case "Thiago":
                            await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Bom dia Thiago, Vamos deixar mais um indicador verdinho?");
                            break;
                        case "Jaime":
                            await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Bom dia Jaime, Já fez Kambam com seu chefe?");
                            break;
                    }

                }

                else if (e.Message.Text.ToLower().Contains("boa tarde"))
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Boa Tarde " + e.Message.From.FirstName);
                else if (e.Message.Text.ToLower().Contains("tomé"))
                {
                    wit.Consulta(e.Message.Text.Replace("?", ""));
                    try
                    {
                        if (wit.Entities.wikipedia_search_query[0].value != null)
                        {
                            await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Não sei muito bem, mas o Google diz o seguinte :\n\n\n " + Search.Execute(wit.Entities.wikipedia_search_query[0].value));
                        }
                        else
                        {
                            Console.WriteLine(wit.Entities.wikipedia_search_query[0].value);
                            Search.Execute(wit.Entities.wikipedia_search_query[0].value);
                            await Bot.SendTextMessageAsync(e.Message.Chat.Id, acoes.seuitch(wit.Entities.Intent[0].values));
                        }


                        // await Bot.SendTextMessageAsync(e.Message.Chat.Id, acoes.seuitch(wit.Entities.Intent[0].values));
                    }
                    catch (LimiteExcedidoException ex)
                    {
                        await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Desculpa " + e.Message.From.FirstName + "\nNão foi póssível realizar a pesquisa \n" +
                           ex.Message);
                    }
                    catch (Exception ex)
                    {
                        await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Desculpa " + e.Message.From.FirstName + "\nNão consegui compreender o comando \n" +
                        "Em breve ficarei mais esperto");
                    }



                }

                else if (e.Message.Text.ToLower().Contains("meu deus"))
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, "O que foi " + e.Message.From.FirstName + "?");



                else if (e.Message.Text.Contains("pulo"))
                {
                    await Bot.SendChatActionAsync(e.Message.Chat.Id, ChatAction.UploadPhoto);

                    const string file = @"pulo.png";

                    var fileName = file.Split(Path.DirectorySeparatorChar).Last();

                    using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        var fts = new FileToSend(fileName, fileStream);

                        await Bot.SendPhotoAsync(
                            e.Message.Chat.Id,
                            fts,
                            "Ó o pulo");
                    }
                }
            } else if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.StickerMessage)
            {
                if (e.Message.Sticker.FileId == "CAADAQADtQADw-oiCFL8FtKsYHNlAg" || e.Message.Sticker.FileId == "CAADAQADqgADw-oiCE4kJLRztel-Ag" || e.Message.Sticker.FileId == "CAADAQADswADw-oiCKXvbVyYMqeoAg")
                {
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Páre de ficar mandando esses Sticker lixo meu amigo");
                    //Console.WriteLine(e.Message.Sticker.FileId);
                } else
                Console.WriteLine("não entrou \n " + e.Message.Sticker.FileId);
               
              // await  Bot.PromoteChatMemberAsync(e.Message.Chat.Id,e.Message.From.Id);
            }




        }



    }
}
