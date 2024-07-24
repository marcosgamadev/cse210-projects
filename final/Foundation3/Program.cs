using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Address address1 = new Address("Av. Paulista, 1578", "São Paulo", "SP", "Brasil");
        Address address2 = new Address("Rua das Flores, 45", "Rio de Janeiro", "RJ", "Brasil");
        Address address3 = new Address("Praça da Sé, 100", "Belo Horizonte", "MG", "Brasil");

   
        Event lecture = new Lecture("Palestra de Tecnologia", "Uma palestra sobre as últimas inovações em tecnologia.", DateTime.Now.AddDays(10), "10:00 AM", address1, "Dr. João Silva", 200);
        Event reception = new Reception("Evento de Networking", "Encontro para profissionais da indústria se conhecerem.", DateTime.Now.AddDays(15), "6:00 PM", address2, "rsvp@evento.com.br");
        Event outdoorGathering = new OutdoorGathering("Festival de Verão", "Uma celebração ao ar livre com comida e música.", DateTime.Now.AddDays(20), "1:00 PM", address3, "Ensolarado com possibilidade de chuvas isoladas");

      
        List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

      
        foreach (Event ev in events)
        {
            Console.WriteLine("Standard Details:");
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine();

            Console.WriteLine("Full Details:");
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine();

            Console.WriteLine("Short Description:");
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine();
        }
    }
}
