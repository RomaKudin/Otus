namespace PrototypeDZ.Interface
{
    /// <summary>
    /// Интерфейс для реализации паттерна "Прототип".
    /// Позволяет создавать клон объекта.
    /// </summary>
    /// <typeparam name="T">Тип объекта, который будет клонироваться.</typeparam>
    public interface IMyCloneable<T>
    {
        /// <summary>
        /// Метод для клонирования объекта.
        /// </summary>
        /// <returns>Возвращает новый экземпляр объекта типа <typeparamref name="T"/>.</returns>
        T MyClone();
    }
}
