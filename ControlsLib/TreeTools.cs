using System.Windows;
using System.Windows.Media;

namespace ControlsLib
{
    public static class TreeTools
    {
        /// <summary>
        /// Возвращает первый элемент дерева, соответствующий заданному типу, включая корень
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <returns>Первый элемент дерева удовлетворяющий заданному типу, включая корень</returns>

        public static T? GetVisualChild<T>(DependencyObject root) where T : DependencyObject
        {
            foreach (var child in GetVisualTree(root))
                if (child is T result)
                    return result;
            return null;
        }

        public static FrameworkElement? GetVisualChild(DependencyObject root, string name)
        {
            foreach (var child in GetVisualTree(root))
                if (child is FrameworkElement frameworkElement && frameworkElement.Name.Equals(name))
                    return frameworkElement;
            return null;
        }

        public static T? GetVisualParent<T>(DependencyObject element) where T : DependencyObject
        {
            DependencyObject? currentParent = VisualTreeHelper.GetParent(element);
            while (currentParent != null)
            {
                if (currentParent is T result)
                    return result;
                currentParent = VisualTreeHelper.GetParent(currentParent);
            }
            return null;
        }

        public static T? GetLogicalChild<T>(DependencyObject root) where T : DependencyObject
        {
            foreach (var child in GetLogicalTree(root))
                if (child is T result)
                    return result;
            return null;
        }


        public static FrameworkElement? GetLogicalChild(DependencyObject root, string name)
        {
            foreach (var child in GetLogicalTree(root))
                if (child is FrameworkElement frameworkElement && frameworkElement.Name.Equals(name))
                    return frameworkElement;
            return null;
        }

        public static T? GetChild<T>(DependencyObject root) where T: DependencyObject
        {
            var visualTree = GetVisualTree(root);
            foreach(var visualChild in visualTree)
            {
                if (visualChild is T)
                    return (T)visualChild;
                var logicalChild = GetLogicalChild<T>(visualChild);
                if (logicalChild != null)
                    return logicalChild;
            }
            return null;
        }
        /// <summary>
        /// Возвращает набор элементов визуального дерева, соответствующих заданному типу, включая корень
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <returns>Набор элементов визуального дерева, соответствующих заданному типу, включая корень</returns>

        public static IEnumerable<T> GetVisualChildren<T>(DependencyObject root) where T : DependencyObject
            => GetVisualTree(root).OfType<T>();

        /// <summary>
        /// Возвращает коллекцию всех элементов визуального дерева
        /// </summary>
        /// <param name="root"></param>
        /// <returns>Коллекция всех элементов визуального дерева</returns>

        public static IEnumerable<DependencyObject> GetVisualTree(DependencyObject root)
        {
            Queue<DependencyObject> queue = new();
            DependencyObject current;

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                yield return current;
                int childrenCount = VisualTreeHelper.GetChildrenCount(current);
                for (int i = 0; i < childrenCount; i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(current, i);
                    queue.Enqueue(child);
                }
            }
        }

        /// <summary>
        /// Возвращает коллекцию всех элементов логического дерева
        /// </summary>
        /// <param name="root"></param>
        /// <returns>Коллекция всех элементов логического дерева</returns>
        public static IEnumerable<DependencyObject> GetLogicalTree(DependencyObject root)
        {
            Queue<DependencyObject> queue = new();
            DependencyObject current;
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                current = queue.Dequeue();

                yield return current;

                var children = LogicalTreeHelper.GetChildren(current);

                foreach(var child in children)
                {
                    if (child is DependencyObject dp)
                        queue.Enqueue(dp);
                }
            }

        }

    }
}
