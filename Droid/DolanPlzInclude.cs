using System.Collections.Specialized;
using System.Windows.Input;
using Android.Widget;

namespace TechTalk.Droid
{
    /// <summary>
    ///               ▄██▀
    ///      ▄▄▄▄▄▄▄████▀▀
    ///    ▄█▀░░░░░░░░░▀▀▀▀▀▄▄
    ///   █░░░░░░░░░░░░░░░░░░█
    ///   █░▄█████████████████
    ///  ▄███▀▀▀▀▀▀▀▀▀▀▀▀▀███▀
    //  ▄▀▀░░░▄▄░░░░░░░░░▄▄░░▀▀▄
    ///▄▀░░░▄▀▄▄▀█░▄▀▄░█▀▄▄▀▄░░░▀▄
    ///█░░░▄▀▀▀▀▀▀▀░░░▀▀▀▀▀▀▀▄░░░█
    ///█░░▀██▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██▀░░█
    ///█░░░░▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀░░░░░█
    ///█░░░░░░░░░░░░░░░░░░░░░░░░░█
    ///▀▄░░░░░░░░░░░░░░░░░░░░░░░▄▀
    ///  ▀▄░░░░░░░░░░░░░░░░░░░▄▀
    /// </summary>
    public class DolanPlzInclude
    {
        public void Include(Button button)
        {
            button.Click += (s, e) => button.Text = button.Text + string.Empty;
            button.Enabled = button.Enabled;
        }

        public void Include(ImageButton button)
        {
            button.Alpha = button.Alpha;
        }

        public void Include(CheckBox checkBox)
        {
            checkBox.CheckedChange += (sender, args) => checkBox.Checked = !checkBox.Checked;
        }

        public void Include(Switch switchControl)
        {
            switchControl.CheckedChange += (sender, args) => switchControl.Checked = !switchControl.Checked;
        }

        public void Include(TextView text)
        {
            text.TextChanged += (sender, args) => text.Text = string.Empty + text.Text;
            text.Selected = text.Selected;
        }

        public void Include(CompoundButton cb)
        {
            cb.CheckedChange += (sender, args) => cb.Checked = !cb.Checked;
        }

        public void Include(SeekBar sb)
        {
            sb.ProgressChanged += (sender, args) => sb.Progress = sb.Progress + 1;
        }

        public void Include(ProgressBar pb)
        {
            pb.Indeterminate = true;
        }

        public void Include(INotifyCollectionChanged changed)
        {
            changed.CollectionChanged += (s, e) =>
            {
                var test = string.Format("{0}{1}{2}{3}{4}", e.Action, e.NewItems, e.NewStartingIndex, e.OldItems, e.OldStartingIndex);
                test = test + test;
            };
        }

        public void Include(ICommand command)
        {
            command.CanExecuteChanged += (s, e) =>
            {
                if (command.CanExecute(null))
                {
                    command.Execute(null);
                }
            };
        }

    }
}