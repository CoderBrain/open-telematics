using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTelematics.Extensions;

namespace OpenTelematics.DiagnosticProvider
{
    public abstract class DiagnosticProvider
    {
        private Distance _Speed;
        public Distance Speed
        {
            get { return _Speed; }
            set
            {
                if (value.Equals(_Speed)) return;

                _Speed = value;
                if (OnSpeedChanged != null) OnSpeedChanged.Invoke(this, new SpeedChangedEventArgs(_Speed));
            }
        }

        private Volume _Fuel;
        public Volume Fuel
        {
            get { return _Fuel; }
            set
            {
                if (value.Equals(_Fuel)) return;

                _Fuel = value;
                if (OnFuelChanged != null) OnFuelChanged.Invoke(this, new FuelChangedEventArgs(_Fuel, _FuelCapacity));
            }
        }

        private Volume _FuelCapacity;
        public Volume FuelCapacity
        {
            get { return _FuelCapacity; }
            set
            {
                if (value.Equals(_FuelCapacity)) return;

                _FuelCapacity = value;
                if (OnFuelChanged != null) OnFuelChanged.Invoke(this, new FuelChangedEventArgs(_Fuel, _FuelCapacity));
            }
        }

        private int _RPM;
        public int RPM
        {
            get { return _RPM; }
            set
            {
                if (value.Equals(_RPM)) return;

                _RPM = value;
                if (OnRPMChanged != null) OnRPMChanged.Invoke(this, new RPMChangedEventArgs(_RPM, _RPMMax));
            }
        }

        private int _RPMMax;
        public int RPMMax
        {
            get { return _RPMMax; }
            set
            {
                if (value.Equals(_RPMMax)) return;

                _RPMMax = value;
                if (OnRPMChanged != null) OnRPMChanged.Invoke(this, new RPMChangedEventArgs(_RPM, _RPMMax));
            }
        }

        public EventHandler<FuelChangedEventArgs> OnFuelChanged;
        public EventHandler<SpeedChangedEventArgs> OnSpeedChanged;
        public EventHandler<RPMChangedEventArgs> OnRPMChanged;
    }

    #region Events

    public class RPMChangedEventArgs
    {
        public int Current { get; private set; }
        public int Maximum { get; private set; }
        public decimal Percentage { get; private set; }

        public RPMChangedEventArgs(int current, int maximum)
        {
            Current = current;
            Maximum = maximum;

            Percentage = (current / maximum) * 100;
        }
    }

    public class FuelChangedEventArgs
    {
        public Volume Current { get; private set; }
        public Volume Maximum { get; private set; }
        public decimal Percentage { get; private set; }

        public FuelChangedEventArgs(Volume current, Volume maximum)
        {
            Current = current;
            Maximum = maximum;

            Percentage = (current.Milelitres / maximum.Milelitres) * 100;
        } 
    }

    public class SpeedChangedEventArgs
    {
        public Distance Speed { get; private set; }
        public SpeedChangedEventArgs(Distance speed) { Speed = speed; }
    }

    #endregion
}
