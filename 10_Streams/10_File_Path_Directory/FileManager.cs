namespace _10_File_Path_Directory
{
    public enum Direction
    {
        Up,
        Down
    }

    public class FileManager
    {
        private string root = "C:\\itstep";
        private string currentDir;
        private int selectedItem = 0;
        private List<object> children;
        private Stack<string> history;

        public FileManager()
        {
            history = new Stack<string>();
            currentDir = root;
            children = new List<object>();
            SetChildren();
        }

        private void SetChildren()
        {
            children.Clear();
            foreach (var dir in Directory.GetDirectories(currentDir))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                children.Add(dirInfo);
            }
            foreach (var file in Directory.GetFiles(currentDir))
            {
                FileInfo fileInfo = new FileInfo(file);
                children.Add(fileInfo);
            }
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    if(selectedItem > 0)
                    {
                        selectedItem--;
                    }
                    break;
                case Direction.Down:
                    if(selectedItem < children.Count - 1)
                    {
                        selectedItem++;
                    }
                    break;
            }
            
        }

        public void Back()
        {
            if(history.Count > 0)
            {
                currentDir = history.Pop();
                SetChildren();
                selectedItem = 0;
            }
        }

        public void Enter()
        {
            object child = children[selectedItem];

            if (child is DirectoryInfo)
            {
                DirectoryInfo dir = (DirectoryInfo)child;
                history.Push(currentDir);
                currentDir = dir.FullName;
                SetChildren();
                selectedItem = 0;
            }
        }

        public void PrintChildren()
        {
            for (int i = 0; i < children.Count; i++)
            {
                string childName = "";

                DirectoryInfo? dir = children[i] as DirectoryInfo;

                if(dir != null)
                {
                    childName = dir.Name;
                }
                else
                {
                    FileInfo? file = children[i] as FileInfo;
                    childName = file.Name;
                }


                if (i == selectedItem)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"->{childName}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {childName}");
                }
            }
        }
    }
}
