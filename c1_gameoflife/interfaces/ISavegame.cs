using c1_gameoflife.model;

namespace c1_gameoflife.interfaces
{
    interface ISavegame
    {
        Spielfeld load(string filePath);

        void save(Spielfeld spielfeld, string filePath);
    }
}
