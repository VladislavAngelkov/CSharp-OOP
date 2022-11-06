
namespace MilitaryElite.Engines
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using MilitaryElite.Exceptions;
    using MilitaryElite.IO.Interfaces;
    using MilitaryElite.Models;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] soldierInfo = reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

            List<Soldier> soldiers = new List<Soldier>();

            while (soldierInfo[0] != "End")
            {
                string type = soldierInfo[0];
                int id = int.Parse(soldierInfo[1]);
                string firstName = soldierInfo[2];
                string lastName = soldierInfo[3];
                decimal salary = decimal.Parse(soldierInfo[4]);

                Soldier soldier = null;

                if (type == "Private")
                {
                    soldier = new Private(firstName, lastName, id, salary);
                }
                else if (type == "LieutenantGeneral")
                {
                    int[] privatesId = soldierInfo.Skip(5).Select(int.Parse).ToArray();
                    List<Private> privates = new List<Private>();

                    foreach (var prId in privatesId)
                    {
                        privates.Add((Private)soldiers.First(s => s.Id == prId && s is Private));
                    }

                    soldier = new LieutenantGeneral(firstName, lastName, id, salary, privates);
                }
                else if (type == "Engineer")
                {
                    string corps = soldierInfo[5];
                    string[] repairsInfo = soldierInfo.Skip(6).ToArray();
                    List<Repair> repairs = new List<Repair>();

                    for (int i = 0; i < repairsInfo.Length; i += 2)
                    {
                        Repair repair = new Repair(repairsInfo[i], int.Parse(repairsInfo[i + 1]));
                        repairs.Add(repair);
                    }

                    try
                    {
                        soldier = new Engineer(firstName, lastName, id, salary, corps, repairs);
                    }
                    catch (CorpsException ex)
                    {
                        soldierInfo = reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                }
                else if (type == "Commando")
                {
                    string corps = soldierInfo[5];

                    string[] missionsInfo = soldierInfo.Skip(6).ToArray();
                    List<Mission> missions = new List<Mission>();

                    for (int i = 0; i < missionsInfo.Length; i += 2)
                    {
                        try
                        {
                            Mission mission = new Mission(missionsInfo[i], missionsInfo[i + 1]);
                            missions.Add(mission);
                        }
                        catch (MissionStateException ex)
                        {

                        }
                    }

                    try
                    {
                        soldier = new Commando(firstName, lastName, id, salary, corps, missions);
                    }
                    catch (CorpsException ex)
                    {
                        soldierInfo = reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                    
                }
                else if (type == "Spy")
                {
                    int codeNumber = (int)salary;
                    soldier = new Spy(firstName, lastName, id, codeNumber);
                }

                soldiers.Add(soldier);

                soldierInfo = reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var soldier in soldiers)
            {
                writer.WriteLine(soldier.ToString());
            }
        }
    }
}
