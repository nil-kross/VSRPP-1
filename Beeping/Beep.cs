using System;

namespace Study.Beeping
{
    public class Beep : Object
    {
        private UInt16 _frequencyValue;
        private UInt16 _durationValue;

        public UInt16 Frequency {
            get => _frequencyValue;
        }
        
        public UInt16 Duration {
            get => _durationValue;
        }
        
        public Beep(
            UInt16 frequency, 
            UInt16 duration
        ) {
            _frequencyValue = frequency;
            _durationValue = duration;
        }

        public static bool operator==(
            Beep firstBeep, 
            Beep secondBeep
        ) {
            bool isEquals = false;

            if (
                Object.Equals(
                    firstBeep,
                    null
                ) &&
                Object.Equals(
                    secondBeep,
                    null
                )
            ) {
                isEquals = true;
            } else if (
                !Object.Equals(
                    firstBeep,
                    null
                ) &&
                !Object.Equals(
                    secondBeep,
                    null
                )
            ) {
                isEquals = firstBeep.Frequency == secondBeep.Frequency &&
                           firstBeep.Duration == secondBeep.Duration;
            }

            return isEquals;
        }

        public static bool operator !=(
            Beep firstBeep,
            Beep secondBeep
        ) {
            return !(firstBeep == secondBeep);
        }

        public override bool Equals(object @object)
        {
            bool isEquals = false;

            if (
                @object != null &&
                @object.GetType() == typeof(Beep)
            ) {
                isEquals = (Beep)@object == this;
            } 

            return isEquals;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() +
                   this.Frequency.GetHashCode() +
                   this.Duration.GetHashCode();
        }

        public override String ToString()
        {
            return String.Format(
                "Frequency: {0}, Duration: {1}",
                this.Frequency,
                this.Duration
            );
        }
    }
}