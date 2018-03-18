using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tome
{
    public class Acoes
    {
        /// <summary>
        /// Comando tem que muitos cases
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public string seuitch(string txt)
        {
            switch (txt)
            {
                case "Horário_get":
                    string mensagem = "Agora são " + DateTime.Now.ToString("HH:mm");
                    return mensagem;


                case "Estado_get":
                    string mensagem2 = "Eu estou bem, obrigado por perguntar. \nO Luan está fazendo algumas melhorias do Greg em mim, então vou ficar melhor ainda ";
                    return mensagem2;

                case "Palavrao":
                    string mensagem3 = "Amigo não é bom esculhambar os outros. Tenha mais respeito!";
                    return mensagem3;

                case "Chimbinha":
                    string mensagem4 = "Chimbinha é o melhor guitarrista do universo.";
                    return mensagem4;

                case "Elogio":
                    string mensagem5 = "Obrigado! O Luan está me ajudando a evoluir.";
                    return mensagem5;

                default:
                    return string.Empty;

            }
        }


    }
}
