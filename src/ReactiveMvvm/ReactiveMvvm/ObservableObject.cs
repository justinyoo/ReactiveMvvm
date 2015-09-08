﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ReactiveMvvm
{
#pragma warning disable 1591
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) =>
            PropertyChanged?.Invoke(this, e);

        protected void OnPropertyChanged(string propertyName) =>
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "The 'x' name is a general term to express one of operands")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "The 'y' name is a general term to express one of operands")]
        protected virtual bool Equals<T>(T x, T y) =>
            EqualityComparer<T>.Default.Equals(x, y);

        protected bool SetValue<T>(
            ref T store, T value, [CallerMemberName]string propertyName = null)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }
            if (Equals(store, value))
            {
                return false;
            }

            store = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
