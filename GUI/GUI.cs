using BLL;
using BLL.BO;
using System;
using System.Collections.Generic;
using static System.Console;

namespace GUI
{
    class GUI
    {
        public BLLFacade BLLFacade = new BLLFacade();

        public GUI()
        {
            MainMenu();
        }

        

        private void MainMenu()
        {

            while (true)
            {
                WriteLine("What would you like to do?");
                WriteLine("----------------------------------------------------------------------------------------------");
                List<string> items = new List<string>
                {
                    "Add videos.",
                    "View videos.",
                    "Edit vidos.",
                    "Delete videos.",
                    "Exit"
                };
                int index = 1;
                foreach (var i in items)
                {
                    WriteLine(index + " : " + i);
                    index++;
                }
                switch (ReadLine())
                {
                    case "1":
                        AddMenu();
                        break;
                    case "2":
                        ViewMenu();
                        break;
                    case "3":
                        EditMenu();
                        break;
                    case "4":
                        DeleteMenu();
                        break;
                    case "5":
                        ExitMenu();
                        break;
                    default:
                        Clear();
                        WriteLine("Please write a valid option.");
                        break;
                }
            }

        }


        private void AddMenu()
        {
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------");
            WriteLine("Welcome to the add menu.");
            WriteLine("Here you can add new videos.");
            WriteLine("----------------------------------------------------------------------------------------------");
            while (true)
            {
                WriteLine("Actions:");
                WriteLine("1 - Add new video | 2 - Add multiple | 3 - Go back");
                switch (ReadLine())
                {
                    case "1":
                        Add();
                        break;
                    case "2":
                        Clear();
                        Multi();
                        break;
                    case "3":
                        Clear();
                        MainMenu();
                        break;
                    default:
                        Clear();
                        WriteLine("Invalid input.");
                        break;
                }
            }
        }

        private void Multi()
        {
            List<VideoBO> videos = new List<VideoBO>();
            WriteLine("You can now add multiple videos.");
            while (true)
            {
                WriteLine("Enter video name:");
                string name = ReadLine();
                WriteLine("Enter video author:");
                string author = ReadLine();
                WriteLine("Enter genre:");
                string genre = ReadLine();
                WriteLine("Thank you! The new video has been added.");
                VideoBO tempVid = new VideoBO()
                {
                    Title = name,
                    Author = author,
                    Genre = genre
                };
                videos.Add(tempVid);
                WriteLine("Actions:");
                WriteLine("1 - Add another | 2 - Go back");
                switch (ReadLine())
                {
                    case "1":
                        break;
                    case "2":
                        Clear();
                        BLLFacade.VideoService.AddVideos(videos);
                        AddMenu();
                        break;
                    default:
                        Clear();
                        WriteLine("Invalid input.");
                        break;
                }
            }
        }

        private void Add()
        {
            WriteLine("Enter video name:");
            string name = ReadLine();
            WriteLine("Enter video author:");
            string author = ReadLine();
            WriteLine("Enter genre:");
            string genre = ReadLine();
            WriteLine("Thank you! The new video has been added.");
            VideoBO tempVid = new VideoBO()
            {
                Title = name,
                Author = author,
                Genre = genre
            };
            BLLFacade.VideoService.Add(tempVid);
            ReadLine();
            AddMenu();
        }

        private void ViewAllVids()
        {
            WriteLine("Current videos: ");
            foreach (var vid in BLLFacade.VideoService.GetAll())
            {
                WriteLine(vid.ToString());
            }
        }

        private void ViewMenu()
        {
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------");
            WriteLine("Welcome to the view menu.");
            WriteLine("Here you can view all your videos.");
            WriteLine("----------------------------------------------------------------------------------------------");
            WriteLine("Actions:");
            WriteLine("1 - Search | 2 - Exit");

            ViewAllVids();
            while (true)
            {
                switch (ReadLine())
                {
                    case "1":
                        SearchMenu();
                        break;
                    case "2":
                        Clear();
                        MainMenu();
                        break;
                    default:
                        Clear();
                        WriteLine("Invalid input. Write 1 to search, or 2 to exit.");
                        break;
                }
            }
        }

        private void SearchMenu()
        {
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------");
            WriteLine("You can now search for specific videos.");
            WriteLine("Enter a search parameter!");
            WriteLine("----------------------------------------------------------------------------------------------");
            string filter = ReadLine().ToLower();

            WriteLine("Results: /n");

            foreach (var i in BLLFacade.VideoService.Filter(filter))
            {
                WriteLine(i.ToString());
            }
            WriteLine();
            while (true)
            {
                WriteLine("Actions:");
                WriteLine("1 - Search again | 2 - Go back");
                switch (ReadLine())
                {
                    case "1":
                        SearchMenu();
                        break;
                    case "2":
                        ViewMenu();
                        break;
                    default:
                        Clear();
                        WriteLine("Invalid input.");
                        break;
                }
            }
        }

        private void EditMenu()
        {
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------");
            WriteLine("Welcome to the edit menu.");
            WriteLine("Here you can edit all our videos.");
            WriteLine("----------------------------------------------------------------------------------------------");
            while (true)
            {
                WriteLine("Actions:");
                WriteLine("1 - Edit video | 2 - Go back/n");
                ViewAllVids();
                switch (ReadLine())
                {
                    case "1":
                        Edit();
                        break;

                    case "2":
                        Clear();
                        MainMenu();
                        break;
                    default:
                        Clear();
                        WriteLine("Invalid input.");
                        break;
                }
            }
        }

        private void Edit()
        {
            if (BLLFacade.VideoService.GetCount() == 0)
            {
                WriteLine("There are no videos to edit.");
                ReadLine();
                Clear();
                MainMenu();
            }
            while (true)
            {
                WriteLine("Enter ID of video to edit.");
                if (!int.TryParse(ReadLine(), out int ID))
                {
                    WriteLine("Invalid input. Whole numbers only.");
                }
                else
                {
                    VideoBO video = BLLFacade.VideoService.Get(ID);
                    if (video != null)
                    {

                        WriteLine("Editing " + video.ToString());
                        WriteLine("Enter title:");
                        video.Title = ReadLine();
                        WriteLine("Enter author:");
                        video.Author = ReadLine();
                        WriteLine("Enter genre:");
                        video.Genre = ReadLine();
                        WriteLine("Video has been edited!");
                        BLLFacade.VideoService.Update(video);
                        ReadLine();
                        EditMenu();


                    }
                    else
                    {
                        WriteLine("No match found.");
                        ReadLine();
                        EditMenu();
                    }
                }
            }
        }

        private void DeleteMenu()
        {
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------");
            WriteLine("Welcome to the delete menu.");
            WriteLine("Here you can delete any of your videos.");
            WriteLine("----------------------------------------------------------------------------------------------/n");

            while (true)
            {
                WriteLine("Actions:");
                WriteLine("1 - Delete a video | 2 - Go back/n");
                WriteLine("Current Videos:");
                foreach (var vid in BLLFacade.VideoService.GetAll())
                {
                    WriteLine(vid.ToString());
                }
                switch (ReadLine())
                {
                    case "1":
                        Delete();
                        break;

                    case "2":
                        Clear();
                        MainMenu();
                        break;
                    default:
                        Clear();
                        WriteLine("Invalid input.");
                        break;
                }
            }
        }

        private void Delete()
        {
            if (BLLFacade.VideoService.GetCount() == 0)
            {
                WriteLine("There are no videos to delete.");
                ReadLine();
                Clear();
                MainMenu();
            }
            while (true)
            {
                WriteLine("Enter ID of video to delete.");
                if (!int.TryParse(ReadLine(), out int ID))
                {
                    WriteLine("Invalid input. Whole numbers only.");
                }
                else
                {
                    VideoBO vid = BLLFacade.VideoService.Get(ID);

                    if (vid != null)
                    {
                        BLLFacade.VideoService.Delete(ID);
                        Clear();
                        WriteLine("Successfully deleted the video. Press enter to continue.");
                        ReadLine();
                        DeleteMenu();
                    }
                    else
                    {
                        WriteLine("No match found.");
                        DeleteMenu();
                    }
                }
            }
        }

        private void ExitMenu()
        {
            Clear();
            WriteLine("----------------------------------------------------------------------------------------------");
            WriteLine("Woops, you're about to exit the program. Is that right?");
            WriteLine("Actions:");
            WriteLine("Y | N");
            WriteLine("----------------------------------------------------------------------------------------------");
            while (true)
            {
                switch (ReadLine().ToLower())
                {
                    case "y":
                        Environment.Exit(0);
                        break;
                    case "n":
                        MainMenu();
                        break;
                    default:
                        Clear();
                        WriteLine("Invalid input. Write Y to exit or N to cancel.");
                        break;
                }
            }

        }
    }
}