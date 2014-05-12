namespace KeyCur
{
    partial class Configure
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configure));
            this.mouse_panel = new System.Windows.Forms.Panel();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_button = new System.Windows.Forms.Button();
            this.start_button = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.sound_alert = new System.Windows.Forms.CheckBox();
            this.ballon_alert = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.max_wheel_speed = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.wheel_acceleration = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.max_movement_speed = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.movement_acceleration = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.click_speed = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.double_click_delay = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.drag = new KeyCur.KeyInput();
            this.double_click = new KeyCur.KeyInput();
            this.activation = new KeyCur.KeyInput();
            this.down_right = new KeyCur.KeyInput();
            this.down_left = new KeyCur.KeyInput();
            this.up_left = new KeyCur.KeyInput();
            this.up_right = new KeyCur.KeyInput();
            this.mmb = new KeyCur.KeyInput();
            this.down = new KeyCur.KeyInput();
            this.right = new KeyCur.KeyInput();
            this.left = new KeyCur.KeyInput();
            this.up = new KeyCur.KeyInput();
            this.wheel_down = new KeyCur.KeyInput();
            this.wheel_up = new KeyCur.KeyInput();
            this.rmb = new KeyCur.KeyInput();
            this.lmb = new KeyCur.KeyInput();
            this.mouse_panel.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.max_wheel_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wheel_acceleration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_movement_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movement_acceleration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.click_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.double_click_delay)).BeginInit();
            this.SuspendLayout();
            // 
            // mouse_panel
            // 
            this.mouse_panel.BackgroundImage = global::KeyCur.Properties.Resources.mouse;
            this.mouse_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mouse_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mouse_panel.Controls.Add(this.down_right);
            this.mouse_panel.Controls.Add(this.down_left);
            this.mouse_panel.Controls.Add(this.up_left);
            this.mouse_panel.Controls.Add(this.up_right);
            this.mouse_panel.Controls.Add(this.mmb);
            this.mouse_panel.Controls.Add(this.down);
            this.mouse_panel.Controls.Add(this.right);
            this.mouse_panel.Controls.Add(this.left);
            this.mouse_panel.Controls.Add(this.up);
            this.mouse_panel.Controls.Add(this.wheel_down);
            this.mouse_panel.Controls.Add(this.wheel_up);
            this.mouse_panel.Controls.Add(this.rmb);
            this.mouse_panel.Controls.Add(this.lmb);
            this.mouse_panel.Location = new System.Drawing.Point(12, 14);
            this.mouse_panel.Name = "mouse_panel";
            this.mouse_panel.Size = new System.Drawing.Size(330, 510);
            this.mouse_panel.TabIndex = 2;
            this.mouse_panel.Click += new System.EventHandler(this.mouse_panel_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "KeyCur is Disabled";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activateToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(118, 54);
            // 
            // activateToolStripMenuItem
            // 
            this.activateToolStripMenuItem.Name = "activateToolStripMenuItem";
            this.activateToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.activateToolStripMenuItem.Text = "&Activate";
            this.activateToolStripMenuItem.Click += new System.EventHandler(this.start_button_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(538, 537);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(104, 33);
            this.exit_button.TabIndex = 1;
            this.exit_button.Text = "Exit";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(406, 537);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(126, 33);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "Start (F11)";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // timer
            // 
            this.timer.Interval = 3;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.sound_alert);
            this.panel1.Controls.Add(this.ballon_alert);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.max_wheel_speed);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.wheel_acceleration);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.max_movement_speed);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.movement_acceleration);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.click_speed);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.double_click_delay);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.drag);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.double_click);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.activation);
            this.panel1.Location = new System.Drawing.Point(355, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 510);
            this.panel1.TabIndex = 16;
            this.panel1.Click += new System.EventHandler(this.Configure_Click);
            // 
            // sound_alert
            // 
            this.sound_alert.AutoSize = true;
            this.sound_alert.Location = new System.Drawing.Point(252, 354);
            this.sound_alert.Name = "sound_alert";
            this.sound_alert.Size = new System.Drawing.Size(15, 14);
            this.sound_alert.TabIndex = 27;
            this.sound_alert.UseVisualStyleBackColor = true;
            this.sound_alert.CheckedChanged += new System.EventHandler(this.sound_alert_CheckedChanged);
            // 
            // ballon_alert
            // 
            this.ballon_alert.AutoSize = true;
            this.ballon_alert.Location = new System.Drawing.Point(252, 325);
            this.ballon_alert.Name = "ballon_alert";
            this.ballon_alert.Size = new System.Drawing.Size(15, 14);
            this.ballon_alert.TabIndex = 26;
            this.ballon_alert.UseVisualStyleBackColor = true;
            this.ballon_alert.CheckedChanged += new System.EventHandler(this.ballon_alert_CheckedChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(16, 349);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(182, 23);
            this.label11.TabIndex = 19;
            this.label11.Text = "Play Sound Alert on Start/Stop:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Click += new System.EventHandler(this.Configure_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(16, 320);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(182, 23);
            this.label10.TabIndex = 18;
            this.label10.Text = "Show Ballon Tip on Start/Stop:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Click += new System.EventHandler(this.Configure_Click);
            // 
            // max_wheel_speed
            // 
            this.max_wheel_speed.Location = new System.Drawing.Point(192, 274);
            this.max_wheel_speed.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.max_wheel_speed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.max_wheel_speed.Name = "max_wheel_speed";
            this.max_wheel_speed.Size = new System.Drawing.Size(75, 22);
            this.max_wheel_speed.TabIndex = 25;
            this.max_wheel_speed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.max_wheel_speed.ValueChanged += new System.EventHandler(this.max_wheel_speed_ValueChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 23);
            this.label8.TabIndex = 16;
            this.label8.Text = "Max Wheel Speed:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Click += new System.EventHandler(this.Configure_Click);
            // 
            // wheel_acceleration
            // 
            this.wheel_acceleration.Location = new System.Drawing.Point(192, 246);
            this.wheel_acceleration.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.wheel_acceleration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.wheel_acceleration.Name = "wheel_acceleration";
            this.wheel_acceleration.Size = new System.Drawing.Size(75, 22);
            this.wheel_acceleration.TabIndex = 24;
            this.wheel_acceleration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.wheel_acceleration.ValueChanged += new System.EventHandler(this.wheel_acceleration_ValueChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(16, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 23);
            this.label9.TabIndex = 14;
            this.label9.Text = "Wheel Acceleration:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Click += new System.EventHandler(this.Configure_Click);
            // 
            // max_movement_speed
            // 
            this.max_movement_speed.Location = new System.Drawing.Point(192, 218);
            this.max_movement_speed.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.max_movement_speed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.max_movement_speed.Name = "max_movement_speed";
            this.max_movement_speed.Size = new System.Drawing.Size(75, 22);
            this.max_movement_speed.TabIndex = 23;
            this.max_movement_speed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.max_movement_speed.ValueChanged += new System.EventHandler(this.max_movement_speed_ValueChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "Max Movement Speed:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Click += new System.EventHandler(this.Configure_Click);
            // 
            // movement_acceleration
            // 
            this.movement_acceleration.Location = new System.Drawing.Point(192, 190);
            this.movement_acceleration.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.movement_acceleration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.movement_acceleration.Name = "movement_acceleration";
            this.movement_acceleration.Size = new System.Drawing.Size(75, 22);
            this.movement_acceleration.TabIndex = 22;
            this.movement_acceleration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.movement_acceleration.ValueChanged += new System.EventHandler(this.movement_acceleration_ValueChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Movement Acceleration:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Click += new System.EventHandler(this.Configure_Click);
            // 
            // click_speed
            // 
            this.click_speed.Location = new System.Drawing.Point(192, 134);
            this.click_speed.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.click_speed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.click_speed.Name = "click_speed";
            this.click_speed.Size = new System.Drawing.Size(75, 22);
            this.click_speed.TabIndex = 20;
            this.click_speed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.click_speed.ValueChanged += new System.EventHandler(this.click_speed_ValueChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Click Speed (ms):";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Click += new System.EventHandler(this.Configure_Click);
            // 
            // double_click_delay
            // 
            this.double_click_delay.Location = new System.Drawing.Point(192, 162);
            this.double_click_delay.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.double_click_delay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.double_click_delay.Name = "double_click_delay";
            this.double_click_delay.Size = new System.Drawing.Size(75, 22);
            this.double_click_delay.TabIndex = 21;
            this.double_click_delay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.double_click_delay.ValueChanged += new System.EventHandler(this.double_click_delay_ValueChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Double Click Delay (ms):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Click += new System.EventHandler(this.Configure_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Drag Key:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Click += new System.EventHandler(this.Configure_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Double Click Key:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Click += new System.EventHandler(this.Configure_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Activation Key:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.Configure_Click);
            // 
            // drag
            // 
            this.drag.BackColor = System.Drawing.Color.Gray;
            this.drag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drag.Location = new System.Drawing.Point(192, 84);
            this.drag.Name = "drag";
            this.drag.Size = new System.Drawing.Size(75, 23);
            this.drag.TabIndex = 19;
            this.drag.Text = "Start or Release Draging";
            this.drag.ToolTip = "";
            // 
            // double_click
            // 
            this.double_click.BackColor = System.Drawing.Color.Gray;
            this.double_click.Cursor = System.Windows.Forms.Cursors.Hand;
            this.double_click.Location = new System.Drawing.Point(192, 56);
            this.double_click.Name = "double_click";
            this.double_click.Size = new System.Drawing.Size(75, 23);
            this.double_click.TabIndex = 18;
            this.double_click.ToolTip = "Do a double click";
            // 
            // activation
            // 
            this.activation.BackColor = System.Drawing.Color.Gray;
            this.activation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.activation.Location = new System.Drawing.Point(192, 27);
            this.activation.Name = "activation";
            this.activation.Size = new System.Drawing.Size(75, 23);
            this.activation.TabIndex = 17;
            this.activation.ToolTip = "Start/Stop KeyCur";
            // 
            // down_right
            // 
            this.down_right.BackColor = System.Drawing.Color.Gray;
            this.down_right.Cursor = System.Windows.Forms.Cursors.Hand;
            this.down_right.Location = new System.Drawing.Point(190, 361);
            this.down_right.Name = "down_right";
            this.down_right.Size = new System.Drawing.Size(53, 53);
            this.down_right.TabIndex = 12;
            this.down_right.ToolTip = "Move Mouse Down-Right";
            // 
            // down_left
            // 
            this.down_left.BackColor = System.Drawing.Color.Gray;
            this.down_left.Cursor = System.Windows.Forms.Cursors.Hand;
            this.down_left.Location = new System.Drawing.Point(82, 361);
            this.down_left.Name = "down_left";
            this.down_left.Size = new System.Drawing.Size(53, 53);
            this.down_left.TabIndex = 14;
            this.down_left.ToolTip = "Move Mouse Down-Left";
            // 
            // up_left
            // 
            this.up_left.BackColor = System.Drawing.Color.Gray;
            this.up_left.Cursor = System.Windows.Forms.Cursors.Hand;
            this.up_left.Location = new System.Drawing.Point(82, 253);
            this.up_left.Name = "up_left";
            this.up_left.Size = new System.Drawing.Size(53, 53);
            this.up_left.TabIndex = 8;
            this.up_left.ToolTip = "Move Mouse Up-Left";
            // 
            // up_right
            // 
            this.up_right.BackColor = System.Drawing.Color.Gray;
            this.up_right.Cursor = System.Windows.Forms.Cursors.Hand;
            this.up_right.Location = new System.Drawing.Point(190, 253);
            this.up_right.Name = "up_right";
            this.up_right.Size = new System.Drawing.Size(53, 53);
            this.up_right.TabIndex = 10;
            this.up_right.ToolTip = "Move Mouse Up-Right";
            // 
            // mmb
            // 
            this.mmb.BackColor = System.Drawing.Color.Gray;
            this.mmb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mmb.Location = new System.Drawing.Point(137, 53);
            this.mmb.Name = "mmb";
            this.mmb.Size = new System.Drawing.Size(53, 39);
            this.mmb.TabIndex = 6;
            this.mmb.ToolTip = "Middle Mouse Button";
            // 
            // down
            // 
            this.down.BackColor = System.Drawing.Color.Gray;
            this.down.Cursor = System.Windows.Forms.Cursors.Hand;
            this.down.Location = new System.Drawing.Point(136, 361);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(53, 53);
            this.down.TabIndex = 13;
            this.down.ToolTip = "Move Mouse Down";
            // 
            // right
            // 
            this.right.BackColor = System.Drawing.Color.Gray;
            this.right.Cursor = System.Windows.Forms.Cursors.Hand;
            this.right.Location = new System.Drawing.Point(190, 307);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(53, 53);
            this.right.TabIndex = 11;
            this.right.ToolTip = "Move Mouse Right";
            // 
            // left
            // 
            this.left.BackColor = System.Drawing.Color.Gray;
            this.left.Cursor = System.Windows.Forms.Cursors.Hand;
            this.left.Location = new System.Drawing.Point(82, 307);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(53, 53);
            this.left.TabIndex = 15;
            this.left.ToolTip = "Move Mouse Left";
            // 
            // up
            // 
            this.up.BackColor = System.Drawing.Color.Gray;
            this.up.Cursor = System.Windows.Forms.Cursors.Hand;
            this.up.Location = new System.Drawing.Point(136, 253);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(53, 53);
            this.up.TabIndex = 9;
            this.up.ToolTip = "Move Mouse Up";
            // 
            // wheel_down
            // 
            this.wheel_down.BackColor = System.Drawing.Color.Gray;
            this.wheel_down.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wheel_down.Location = new System.Drawing.Point(137, 98);
            this.wheel_down.Name = "wheel_down";
            this.wheel_down.Size = new System.Drawing.Size(53, 23);
            this.wheel_down.TabIndex = 7;
            this.wheel_down.ToolTip = "Wheel Backword";
            // 
            // wheel_up
            // 
            this.wheel_up.BackColor = System.Drawing.Color.Gray;
            this.wheel_up.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wheel_up.Location = new System.Drawing.Point(137, 24);
            this.wheel_up.Name = "wheel_up";
            this.wheel_up.Size = new System.Drawing.Size(53, 23);
            this.wheel_up.TabIndex = 5;
            this.wheel_up.ToolTip = "Wheel Forward";
            // 
            // rmb
            // 
            this.rmb.BackColor = System.Drawing.Color.Gray;
            this.rmb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rmb.Location = new System.Drawing.Point(216, 53);
            this.rmb.Name = "rmb";
            this.rmb.Size = new System.Drawing.Size(73, 39);
            this.rmb.TabIndex = 4;
            this.rmb.ToolTip = "Right Mouse Button";
            // 
            // lmb
            // 
            this.lmb.BackColor = System.Drawing.Color.Gray;
            this.lmb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lmb.Location = new System.Drawing.Point(38, 53);
            this.lmb.Name = "lmb";
            this.lmb.Size = new System.Drawing.Size(73, 39);
            this.lmb.TabIndex = 3;
            this.lmb.ToolTip = "Left Mouse Button";
            // 
            // Configure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 582);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.mouse_panel);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Configure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Key Cursor :: Configure";
            this.Click += new System.EventHandler(this.Configure_Click);
            this.mouse_panel.ResumeLayout(false);
            this.trayMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.max_wheel_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wheel_acceleration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_movement_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movement_acceleration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.click_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.double_click_delay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mouse_panel;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Button start_button;
        private KeyInput lmb;
        private KeyInput down;
        private KeyInput right;
        private KeyInput left;
        private KeyInput up;
        private KeyInput wheel_down;
        private KeyInput wheel_up;
        private KeyInput rmb;
        private KeyInput mmb;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel1;
        private KeyInput drag;
        private System.Windows.Forms.Label label3;
        private KeyInput double_click;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private KeyInput activation;
        private System.Windows.Forms.NumericUpDown double_click_delay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown click_speed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown max_wheel_speed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown wheel_acceleration;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown max_movement_speed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown movement_acceleration;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem activateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox sound_alert;
        private System.Windows.Forms.CheckBox ballon_alert;
        private System.Windows.Forms.Label label11;
        private KeyInput down_right;
        private KeyInput down_left;
        private KeyInput up_left;
        private KeyInput up_right;
    }
}

