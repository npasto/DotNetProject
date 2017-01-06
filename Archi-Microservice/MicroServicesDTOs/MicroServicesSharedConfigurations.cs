using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServicesDTOs
{
    //configurations partagées pour éviter les erreurs durant le TP ...
    public static class MicroServicesSharedConfigurations
    {
        //address et port du srv qui pousse les stock Feeds
        public const String marketZmqTcpStream = "tcp://127.0.0.1:5556";
        //localisation du fichier qui stocke les infos des actions
        public const String stockLoggerFilePath = "D:\\TMP\\sLog.txt";
        //nom du topic (mot clé) pour identifier la lise ZQM de gestion des actions NASDAQ
        public const String marketPlaceNasdaqTopic = "NASDAQ";
    }
}
