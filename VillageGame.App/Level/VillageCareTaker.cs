using System.Collections.Generic;

namespace VillageGame.App.Level
{
    class VillageCareTaker
    {
        private Stack<VillageMomento> _stack = new Stack<VillageMomento>();

        public void Push(VillageMomento momento)
        {
            _stack.Push(momento);
        }

        public VillageMomento Pop()
        {
            return _stack.Count > 0 ? _stack.Pop() : null;
        }
    }
}
