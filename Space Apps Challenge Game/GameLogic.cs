using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Space_Apps_Challenge_Game
{
    enum QuestionType
    {
        SelectAnswer,
        FullAnsver,
        Fact
    }
    class Question
    {
        public Question(QuestionType t, string l, string q, string A1, string A2, string A3, string A4, string TA)
        {
            type = t;
            location = l;
            question = q;
            a1 = A1;
            a2 = A2;
            a3 = A3;
            a4 = A4;
            trueAnswer = TA;

        }
        public QuestionType type;
        public string location;
        public string question;
        public string a1;
        public string a2;
        public string a3;
        public string a4;
        public string trueAnswer;
    }
    class GameLogic
    {
        public void Save()
        {
            try
            {
                BinaryWriter bw = new BinaryWriter(File.Create("Save.dat"));
                bw.Write(Score);
                bw.Write(level1);
                bw.Write(level2);
                bw.Write(level3);
                bw.Write(level4);
                bw.Write(level5);
                bw.Write(level6);
                bw.Write(level7);
                bw.Write(level8);
                bw.Write(level9);
                bw.Close();
            }
            catch
            {

            }
        }


        public Question[] QuestionData1 =
        {
            new Question(QuestionType.SelectAnswer,"Mercury",
                "1. How long do the day on the surface of Mercury last?",
                "a)	176 days",
                "b)	117 days",
                "c)	10 hours",
                "d)	Nearly 16 hours",
                "1"),
            new Question(QuestionType.SelectAnswer,"Mercury",
                "2. What is the minimum surface temperature \n on the planet?",
                "a)	- 129 °F (- 89°C)",
                "b)	- 280 °F (- 173°C)",
                "c)	- 275 °F (- 170°C)",
                "d)	+ 870 °F (+ 465°C)",
                "3"),
            new Question(QuestionType.SelectAnswer,"Mercury",
                "3. November 3, 1973 NASA sent to the surface of \n the Mercury research probe Mariner-10. \n Which discovery was made?",
                "a)	Mercury does not have any moons or rings",
                "b)	Mercury has a magnetic field",
                "c)	Mercury has an atmosphere",
                "d)	Mercury revolve around the Sun at a speed \n of 105,947 miles(170, 505 kilometers) per hour",
                "2"),
            new Question(QuestionType.SelectAnswer,"Mercury",
                "4. What surface do Mercury have?",
                "a)	The soil is full of iron",
                "b)	Liquid or even gaseous",
                "c)	A lot of ice",
                "d)	A rock of volcanic origin",
                "4"),
            new Question(QuestionType.SelectAnswer,"Mercury",
                "5. How long time do NASA’s interplanetary space \n probe “New Horizons” need to get to the Mercury?",
                "a)	19 hours",
                "b)	40 days",
                "c)	 5 months",
                "d)	Over an year",
                "2")
        };
        public int level1 = 0;
        public Question[] QuestionData2 =
        {
            new Question(QuestionType.SelectAnswer,"Venus",
                "1. What is the Diameter of Venus?",
                "a)	12,100 km",
                "b)	12,800 km",
                "c)	51,000 km",
                "d)	143,000  km",
                "1"),
            new Question(QuestionType.SelectAnswer,"Venus",
                "2. What is the surface pressure on the planet?",
                "a)	At 0.4 – 0.87 kPa",
                "b)	At 9.5 bar(0.95 MPa)",
                "c)	At 92 bar(9.2 MPa)",
                "d)	Range from 100 to 0.1 bar(10 MPa to 10 kPa)",
                "3"),
            new Question(QuestionType.SelectAnswer,"Venus",
                "3. When can Venus be observed from the Earth?",
                "a)	A two hour before sunrise",
                "b)	midday",
                "c)	an hour after sunset",
                "d)	can’t be observed",
                "3"),
            new Question(QuestionType.SelectAnswer,"Venus",
                "4. If a person weighs 70 kg on Earth, flew to Venus, there would she weigh about…",
                "a) 5 kilograms",
                "b) 27 kilograms",
                "c) 12 kilograms",
                "d) 62 kilograms",
                "4"),
            new Question(QuestionType.SelectAnswer,"Venus",
                "5. What mount is there on the Venus?",
                "a)	Mount Maxwell",
                "b)	Mount Vesta",
                "c)	Мolcano Olimp",
                "d)	The wall of Yapet",
                "1")
        };
        public int level2 = 0;
        public Question[] QuestionData3 =
        {
            new Question(QuestionType.SelectAnswer,"Earth",
                "1. What percentage of the land is water?",
                "a)	69",
                "b)	65",
                "c)	74",
                "d)	71",
                "1"),
            new Question(QuestionType.SelectAnswer,"Earth",
                "2. In what year was the Earth first photographed from space?",
                "a)	1935",
                "b)	1946",
                "c)	1962",
                "d)	1973",
                "2"),
            new Question(QuestionType.SelectAnswer,"Earth",
                "3. What is the largest Earth among all the planets of the solar system?",
                "a)	1",
                "b)	7",
                "c)	6",
                "d)	5",
                "4"),
            new Question(QuestionType.SelectAnswer,"Earth",
                "4. Roughly how old is Earth?",
                "a) 4.2 million",
                "b) 4.54 billion",
                "c) 4.54 million",
                "d) 1.3 billion",
                "2"),
            new Question(QuestionType.SelectAnswer,"Earth",
                "5. The biggest mountain on earth",
                "a) Chomolungma",
                "b) Broad Peak",
                "c) Mont Blan",
                "d) Mount Hoverla",
                "1")
        };
        public int level3 = 0;
        public Question[] QuestionData4 =
        {
            new Question(QuestionType.SelectAnswer,"Mars",
                "1. The name of what god  do the planet correspond to",
                "a)	Roman god of war",
                "b)	Roman goddess of love and beauty",
                "c)	Greek and Roman god of heaven",
                "d)	the Roman god of the seas and the navigation",
                "1"),
            new Question(QuestionType.SelectAnswer,"Mars",
                "2. What is the distance between Mars and Sun in astronomical units?",
                "a)	0.4",
                "b)	1.5",
                "c)	5.2",
                "d)	9.4",
                "2"),
                new Question(QuestionType.SelectAnswer,"Mars",
                "3. Point the canyon in Mars",
                "a)	Meriner Valley",
                "b)	Bryce Canyon",
                "c)	Chicksulub",
                "d)	Chanon Canyon",
                "1"),
                new Question(QuestionType.SelectAnswer,"Mars",
                "4. Who was the first to see Mars in the  telescope?",
                "a)	Isaac Newton",
                "b)	Galileo Galilei",
                "c)	Johann Kepler",
                "d)	Stephen Goking",
                "2"),
                new Question(QuestionType.SelectAnswer,"Mars",
                "5. When NASA’s  Phoenix Martian automatic station launched?",
                "a)	1957",
                "b)	1961",
                "c)	1979",
                "d)	2007",
                "4")
        };
        public int level4 = 0;
        public Question[] QuestionData5 =
        {
            new Question(QuestionType.FullAnsver,
                "Jupieter",
                "1. How many satellites does Jupiter have?",
                "","","","",
                "79"),
            new Question(QuestionType.FullAnsver,
                "Jupieter",
                "2. What is the number of Jupiter in the solar system?",
                "","","","",
                "5"),
            new Question(QuestionType.FullAnsver,
                "Jupieter",
                "3. In what year did Jupiter discover?",
                "","","","",
                "1610")


        };
        public int level5 = 0;
        public Question[] QuestionData6 =
        {
            new Question(QuestionType.FullAnsver,
                "Saturn",
                "1. What was the name of a research unit \n" +
                    "that successfully flown through Saturn rings \n" +
                    "between two outer rings F and G on June 30, 2004?",
                "","","","",
                "Cassini's research unit"),
            new Question(QuestionType.FullAnsver,
                "Saturn",
                "2. Saturn appear a pale yellow color \n" +
                    "because of … in its atmosphere.",
                "","","","",
                "Cassini's research unit"),
            new Question(QuestionType.FullAnsver,
                "Saturn",
                "3. The first astronomers thought the rings were … ",
                "","","","",
                "Moons")
        };
        public int level6 = 0;
        public Question[] QuestionData7 =
        {
            new Question(QuestionType.FullAnsver,
                "Uranus",
                "1. How many monthes on Uranus?",
                "","","","",
                "27"),
            new Question(QuestionType.FullAnsver,
                "Uranus",
                "2. How long is the year on Uranus?",
                "","","","",
                "84"),
            new Question(QuestionType.FullAnsver,
                "Uranus",
                "3. Who discovered the planet Uranus?",
                "","","","",
                "William Herschel")
        };
        public int level7 = 0;
        public Question[] QuestionData8 =
        {
            new Question(QuestionType.FullAnsver,
                "Neptune",
                "1. How many hours does the day last on Neptune?",
                "","","","",
                "16"),
            new Question(QuestionType.FullAnsver,
                "Neptune",
                "2. What trace gas gives Neptune \n" +
                    "it's brilliant blue hue?",
                "","","","",
                "Methane"),
            new Question(QuestionType.FullAnsver,
                "Neptune",
                "3. The name of the largest moon of \n" +
                    "the planet Neptune?",
                "","","","",
                "Triton")

        };
        public int level8 = 0;
        public Question[] QuestionData9 =
        {
            new Question(QuestionType.FullAnsver,
                "Pluto",
                "1. Who officially discovered Pluto?",
                "","","","",
                "Clyde Tombaugh"),
            new Question(QuestionType.FullAnsver,
                "Pluto",
                "2. When was Pluto reclassified as a dwarf planet?",
                "","","","",
                "2006"),
            new Question(QuestionType.FullAnsver,
                "Pluto",
                "3. What is the name of the NASA mission to study Pluto? (New Horizons)",
                "","","","",
                "New Horizons")
        };
        public int level9 = 0;

        public event Action End;

        private void check()
        {
            if (level1 >= QuestionData1.Length)
                if (level2 >= QuestionData2.Length)
                    if (level3 >= QuestionData3.Length)
                        if (level4 >= QuestionData4.Length)
                            if (level5 >= QuestionData5.Length)
                                if (level6 >= QuestionData6.Length)
                                    if (level7 >= QuestionData7.Length)
                                        if (level8 >= QuestionData8.Length)
                                            if (level9 >= QuestionData9.Length)
                                            {
                                                End();
                                            }
        }

        public GameLogic()
        {
            try
            {
                BinaryReader br = new BinaryReader(File.OpenRead("Save.dat"));
                Score = br.ReadInt32();
                level1 = br.ReadInt32();
                level2 = br.ReadInt32();
                level3 = br.ReadInt32();
                level4 = br.ReadInt32();
                level5 = br.ReadInt32();
                level6 = br.ReadInt32();
                level7 = br.ReadInt32();
                level8 = br.ReadInt32();
                level9 = br.ReadInt32();
                br.Close();
            } catch { }
        }
        public Question GetQuestion(int id)
        {
            Question q = null;
            switch (id)
            {
                case 1:
                    if (level1 < QuestionData1.Length)
                    {
                        q = QuestionData1[level1++];
                    }
                    break;
                case 2:
                    if (level2 < QuestionData2.Length)
                    {
                        q = QuestionData2[level2++];
                    }
                    break;
                case 3:
                    if (level3 < QuestionData3.Length)
                    {
                        q = QuestionData3[level3++];
                    }
                    break;
                case 4:
                    if (level4 < QuestionData4.Length)
                    {
                        q = QuestionData4[level4++];
                    }
                    break;
                case 5:
                    if (level5 < QuestionData5.Length)
                    {
                        q = QuestionData5[level5++];
                    }
                    break;
                case 6:
                    if (level6 < QuestionData6.Length)
                    {
                        q = QuestionData6[level6++];
                    }
                    break;
                case 7:
                    if (level7 < QuestionData7.Length)
                    {
                        q = QuestionData7[level7++];
                    }
                    break;
                case 8:
                    if (level8 < QuestionData8.Length)
                    {
                        q = QuestionData8[level8++];
                    }
                    break;
                case 9:
                    if (level9 < QuestionData9.Length)
                    {
                        q = QuestionData9[level9++];
                    }
                    break;
                default:
                    break;
            }
            return q;
        }
        public int Score = 0;
        public void SetAnswer(Question q, string answer)
        {
            if (q != null)
            {
                if (answer.ToLower() == q.trueAnswer.ToLower())
                    Score += 10;
                else
                    Score -= 3;
            }
        }



    }
}
