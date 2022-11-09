using NFluent;
using Xunit;

namespace GameOfLife.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Should_not_change_cells_if_all_cells_are_dead()
        {
            GridManager gridManager = new GridManager(1,1);
            var newGrid = gridManager.GetNewState();

            Check.That(newGrid[0, 0].IsAlive).IsFalse();
        }

        [Fact]
        public void Should_not_kill_cell_if_it_has_two_neighbours()
        {
            GridManager gridManager = new GridManager(3,3);
            gridManager.Grid[0, 2].IsAlive = true;
            gridManager.Grid[1, 1].IsAlive = true;
            gridManager.Grid[2, 0].IsAlive = true;

            var newGrid = gridManager.GetNewState();

            Check.That(newGrid[1, 1].IsAlive).IsTrue();
        }

        [Fact]
        public void Should_kill_cell_if_it_has_less_than_two_neighbours()
        {
            GridManager gridManager = new GridManager(2,4);
            gridManager.Grid[1, 0].IsAlive = true;
            gridManager.Grid[1, 1].IsAlive = true;
            gridManager.Grid[1, 2].IsAlive = true;

            var newGrid = gridManager.GetNewState();

            Check.That(newGrid[1, 0].IsAlive).IsFalse();
            Check.That(newGrid[1, 2].IsAlive).IsFalse();
        }

        [Fact]
        public void Should_alive_cell_if_it_has_three_neighbours()
        {
            GridManager gridManager = new GridManager(2,3);
            gridManager.Grid[0, 1].IsAlive = true;
            gridManager.Grid[1, 0].IsAlive = true;
            gridManager.Grid[1, 1].IsAlive = true;

            var newGrid = gridManager.GetNewState();

            Check.That(newGrid[0, 0].IsAlive).IsTrue();
        }

        [Fact]
        public void Should_kill_cell_if_it_has_more_than_three_neighbours()
        {
            GridManager gridManager = new GridManager(4,3);
            gridManager.Grid[0, 2].IsAlive = true;
            gridManager.Grid[1, 1].IsAlive = true;
            gridManager.Grid[2, 0].IsAlive = true;
            gridManager.Grid[2, 1].IsAlive = true;
            gridManager.Grid[2, 2].IsAlive = true;

            var newGrid = gridManager.GetNewState();

            Check.That(newGrid[1, 1].IsAlive).IsFalse();
        }

        [Fact]
        public void Should_count_neighbours_of_cell()
        {

            const int h = 2;
            const int w = 3;
            GridManager gridManager = new GridManager(h,w);
            gridManager.Grid[0, 1].IsAlive = true;
            gridManager.Grid[1, 0].IsAlive = true;
            gridManager.Grid[1, 1].IsAlive = true;

            int nbNeighbours = gridManager.CountNeighbours(0, 1);

            Check.That(nbNeighbours).IsEqualTo(2);
        }
    }
}
