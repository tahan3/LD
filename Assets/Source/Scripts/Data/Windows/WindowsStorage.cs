using Source.Scripts.View;
using UnityEngine;

namespace Source.Scripts.Data.Windows
{
    [CreateAssetMenu(fileName = "WindowsStorage", menuName = "WindowsStorage", order = 0)]
    public class WindowsStorage : KeyValueStorage<WindowType, AWindow>
    {
    }
}