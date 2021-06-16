using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Interfaces {
   public interface ISpelerManager {
        Speler RegistreerSpeler(string naam, int? lengte, int? gewicht);
        Speler SelecteerSpeler(string naam);
        Speler SelecteerSpeler(int spelerId);
        IReadOnlyList<Speler> SelecteerSpelers();
        IReadOnlyList<Transfer> SelecteerTransfers();
        IReadOnlyList<Transfer> SelecteerTransfers(int spelerId);
        void TransfereerSpeler(Speler speler, Team naarTeam, int prijs);
        void VerwijderSpeler(Speler speler);
        void VerwijderSpeler(int spelerId);
        void UpdateSpeler(Speler speler);

    }
}
