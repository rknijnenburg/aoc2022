using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day14
{
    internal class Grid
    {
        private readonly List<(Point Start, Point End)> rocks;

        public char[][] Tiles { get; }

        private readonly HashSet<Point> grains = new HashSet<Point>();

        public int MinX { get; set; }
        public int MinY => 0;
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public Grid(List<(Point Start, Point End)> rocks)
        {
            this.rocks = rocks;

            MinX = rocks.Min(p => Math.Min(p.Start.X, p.End.X));
            MaxX = rocks.Max(p => Math.Max(p.Start.X, p.End.X));
            MaxY = rocks.Max(p => Math.Max(p.Start.Y, p.End.Y));

            Tiles = new char[MaxY + 1][];

            for (int y = 0; y <= MaxY; y++)
            {
                var s = new string('.', MaxX - MinX + 1);
                Tiles[y] = s.ToCharArray();
            }

            foreach (var rock in rocks)
            {
                for (int y = Math.Min(rock.Start.Y, rock.End.Y); y <= Math.Max(rock.Start.Y, rock.End.Y); y++)
                {
                    for (int x = Math.Min(rock.Start.X, rock.End.X); x <= Math.Max(rock.Start.X, rock.End.X); x++)
                        Update(TransformX(x), TransformY(y), '#');
                }
            }
        }

        public int Simulate(Point start, bool hasFloor)
        {
            var transformed = Transform(start);

            Point? grain;

            while ((grain  = AddGrain(transformed, hasFloor)) != null)
                grains.Add(grain.Value);

            return grains.Count;
        }
        
        public Point? AddGrain(Point start, bool hasFloor)
        {
            if (grains.Contains(start))
                return null;

            var grain = start;

            Point? next = grain;
            
            while (next != null)
            {
                next = GetNext(next.Value.X, next.Value.Y, hasFloor);

                if (next == null) 
                    continue;

                if (next.Value.Y > (hasFloor ? MaxY + 1 : MaxY))
                    return null;
                
                grain.X = next.Value.X;
                grain.Y = next.Value.Y;
            }
            
            return grain;
        }

        private Point? GetNext(int x, int y, bool hasFloor)
        {
            if (hasFloor && y + 1 > MaxY - MinY + 1)
                return null;

            if (IsEmpty(x, y + 1))
                return new Point(x, y + 1);

            if (IsEmpty(x - 1, y + 1))
                return new Point(x - 1, y + 1);

            if (IsEmpty(x + 1, y + 1))
                return new Point(x + 1, y + 1);

            return null;
        }

        private void Update(int x, int y, char c)
        {
            Tiles[y][x] = c;
        }

        private bool IsEmpty(int x, int y)
        {
            if (grains.Contains(new Point(x, y)))
                return false;

            return x < 0 || x > MaxX - MinX || y > MaxY - MinY || Tiles[y][x] == '.';
        }

        private Point Transform(Point p)
        {
            return new Point(TransformX(p.X), TransformY(p.Y));
        }

        private int TransformX(int x)
        {
            return x - MinX;
        }

        private int TransformY(int y)
        {
            return y - MinY;
        }

        public void Reset()
        {
            grains.Clear();
        }
    }
}
