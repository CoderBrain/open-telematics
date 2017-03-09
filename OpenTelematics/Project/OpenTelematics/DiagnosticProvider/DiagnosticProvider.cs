using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace OpenTelematics.DiagnosticProvider
{
    public abstract class DiagnosticProvider
    {
        private double _Fuel;
        public double Fuel
        {
            get { return _Fuel; }
            set
            {
                if (value.Equals(_Fuel)) return;

                _Fuel = value;
                if (OnFuelChanged != null) OnFuelChanged.Invoke(this, new FuelChangedEventArgs(_Fuel, _FuelCapacity));
            }
        }

        private double _FuelCapacity;
        public double FuelCapacity
        {
            get { return _FuelCapacity; }
            set
            {
                if (value.Equals(_FuelCapacity)) return;

                _FuelCapacity = value;
                if (OnFuelChanged != null) OnFuelChanged.Invoke(this, new FuelChangedEventArgs(_Fuel, _FuelCapacity));
            }
        }

        private double _RPM;
        public double RPM
        {
            get { return _RPM; }
            set
            {
                if (value.Equals(_RPM)) return;

                _RPM = value;
                if (OnRPMChanged != null) OnRPMChanged.Invoke(this, new RPMChangedEventArgs(_RPM, _RPMMax));
            }
        }

        private double _RPMMax;
        public double RPMMax
        {
            get { return _RPMMax; }
            set
            {
                if (value.Equals(_RPMMax)) return;

                _RPMMax = value;
                if (OnRPMChanged != null) OnRPMChanged.Invoke(this, new RPMChangedEventArgs(_RPM, _RPMMax));
            }
        }

        private GeoCoordinate _Coordinate;
        public GeoCoordinate Coordinate
        {
            get { return _Coordinate; }
            set
            {
                _Coordinate = value;
                if (OnCoordinateChanged != null) OnCoordinateChanged.Invoke(this, value);
            }
        }

        public EventHandler<GeoCoordinate> OnCoordinateChanged;
        public EventHandler<FuelChangedEventArgs> OnFuelChanged;
        public EventHandler<RPMChangedEventArgs> OnRPMChanged;
    }

    #region Events

    public class NumberChangedEventArgs
    {
        public double Current { get; private set; }
        public double Maximum { get; private set; }
        public double Percentage { get; private set; }

        public NumberChangedEventArgs(double current, double maximum)
        {
            Current = current;
            Maximum = maximum;

            Percentage = (current / maximum) * 100;
        }
    }

    public class RPMChangedEventArgs : NumberChangedEventArgs
    {
        public RPMChangedEventArgs(double current, double maximum) : base(current, maximum) { }
    }

    public class FuelChangedEventArgs : NumberChangedEventArgs
    {
        public FuelChangedEventArgs(double current, double maximum) : base(current, maximum) { }
    }

    #endregion
}
