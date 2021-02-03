using System.Windows.Media;

namespace ManagedHelpers.Interfaces
{

    public abstract class DocumentViewModel: NotifableObject
    {
        public string Id { get; set; }

        public virtual object View { get; set; }

        public virtual object ViewId
        {
            get { return this.GetType().Name; }
        }

        public abstract string Title { get; }

        public virtual bool CanClose
        {
            get { return false; }
        }

        public virtual void Deinitialize()
        {
            
        }
        public virtual ImageSource ImageSource { get; set; }
    }
}