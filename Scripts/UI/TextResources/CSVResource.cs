using Godot;
using System;
using System.Security.AccessControl;

public partial class CSVResource : Resource {

	public string[][] Rows { get; private set; }

	public void Write(string[][] rows) {
		this.Rows = rows;
	}

	public string Read(int row, int col) {
		return Rows[row][col];
	}

}
