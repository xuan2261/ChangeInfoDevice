﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinSubTrial.Globals;

namespace WinSubTrial.Forms.Popup
{
    public partial class AutoPhonePopup : Form
    {
        public MainViewModel viewModel { get; set; }
        public AutoPhonePopup()
        {
            InitializeComponent();
        }

        private void snapchatButtonTapped(object sender, EventArgs e)
        {
            if (!viewModel.someDevicesSelected()) return;

            Thread thread = new Thread(new ThreadStart(() =>
            {
                foreach (Device device in viewModel.devicesModel.Where(x => x.isSelected == true))
                {
                    Task.Run(() =>
                    {
                        viewModel.deviceWaitForStop[device.Serial] = false;
                        viewModel.SnapchatApp(device.Serial);
                    });
                }
            }))
            { IsBackground = true };
            thread.Start();
        }

        private void TinderButtonClick(object sender, EventArgs e)
        {
            if (!viewModel.someDevicesSelected()) return;
            Thread thread = new Thread(new ThreadStart(() =>
            {
                foreach (Device device in viewModel.devicesModel.Where(x => x.isSelected == true))
                {
                    Task.Run(() =>
                    {
                        viewModel.deviceWaitForStop[device.Serial] = false;
                        viewModel.TinderAutomation(device.Serial);
                    });
                }
            }))
            { IsBackground = true };
            thread.Start();
        }

        private void ChametButtonClick(object sender, EventArgs e)
        {
            if (!viewModel.someDevicesSelected()) return;
            Thread thread = new Thread(new ThreadStart(() =>
            {
                foreach (Device device in viewModel.devicesModel.Where(x => x.isSelected == true))
                {
                    Task.Run(() =>
                    {
                        viewModel.deviceWaitForStop[device.Serial] = false;
                        viewModel.ChametAutomation(device.Serial);
                    });
                }
            }))
            { IsBackground = true };
            thread.Start();
        }
        private void CamScannerButtonClick(object sender, EventArgs e)
        {
            if (!viewModel.someDevicesSelected()) return;
            Thread thread = new Thread(new ThreadStart(() =>
            {
                foreach (Device device in viewModel.devicesModel.Where(x => x.isSelected == true))
                {
                    Task.Run(() =>
                    {
                        viewModel.deviceWaitForStop[device.Serial] = false;
                        viewModel.CamScannerAutomation(device.Serial);
                    });
                }
            }))
            { IsBackground = true };
            thread.Start();
        }

        private void BigoButtonSMSlick(object sender, EventArgs e)
        {
            BigoButtonClick();
        }

        private void BigoButtonRegisterClick(object sender, EventArgs e)
        {
            BigoButtonClick(false);
        }

        private void BigoButtonClick(bool isSMS = true)
        {
            if (!viewModel.someDevicesSelected()) return;
            Thread thread = new Thread(new ThreadStart(() =>
            {
                foreach (Device device in viewModel.devicesModel.Where(x => x.isSelected == true))
                {
                    Task.Run(() =>
                    {
                        viewModel.deviceWaitForStop[device.Serial] = false;
                        viewModel.BigoAutomation(device.Serial, isSMS);
                    });
                }
            }))
            { IsBackground = true };
            thread.Start();
        }

        private void BigoLiteButtonClick(object sender, EventArgs e)
        {
            if (!viewModel.someDevicesSelected()) return;
            GlobalVariable.isGetPhonenumber = false;
            viewModel.devicesModel.Where(x => x.isSelected == true).AsParallel().ForAll(device =>
            {
                Task.Run(() =>
                {
                    viewModel.deviceWaitForStop[device.Serial] = false;
                    viewModel.BigoLiteAutomation(device.Serial);
                });
            });
        }
        private void snapchatPasswordNET1(object sender, EventArgs e)
        {
            snapchatPasswordRetrieval("net1");
        }
        private void snapchatPasswordNET2(object sender, EventArgs e)
        {
            snapchatPasswordRetrieval("net2");
        }
        private void snapchatPasswordRetrieval(string net)
        {
            if (!viewModel.someDevicesSelected()) return;
            viewModel.devicesModel.Where(x => x.isSelected == true).AsParallel().ForAll(device =>
            {
                Task.Run(() =>
                {
                    viewModel.deviceWaitForStop[device.Serial] = false;
                    viewModel.SnapchatPasswordRetrieval(device.Serial, net);
                });
            });
        }
    }
}
