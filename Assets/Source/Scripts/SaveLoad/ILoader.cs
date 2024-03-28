namespace Source.Scripts.SaveLoad
{
    public interface ILoader<out T>
    {
        public T Load();
    }
}