namespace GridBuildSystem.BuildSystem.Buildings
{
    public interface IPlaceable
    {
        void ChangeColor(bool canBePlaced);
        void OnPlaced();
    }
}