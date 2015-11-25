﻿/*
    Copyright (C) 2014-2015 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.ComponentModel.Composition;

namespace dnSpy.Contracts.Files.TreeView {
	/// <summary>
	/// Finds <see cref="IFileTreeNodeData"/> nodes. Use <see cref="ExportFileTreeNodeDataFinderAttribute"/>
	/// to export an instance.
	/// </summary>
	public interface IFileTreeNodeDataFinder {
		/// <summary>
		/// Returns an existing <see cref="IFileTreeNodeData"/> node or null
		/// </summary>
		/// <param name="fileTreeView">Owner</param>
		/// <param name="ref">Reference</param>
		/// <returns></returns>
		IFileTreeNodeData FindNode(IFileTreeView fileTreeView, object @ref);
	}

	/// <summary>Metadata</summary>
	public interface IFileTreeNodeDataFinderMetadata {
		/// <summary>See <see cref="ExportFileTreeNodeDataFinderAttribute.Order"/></summary>
		double Order { get; }
	}

	/// <summary>
	/// Exports a <see cref="IFileTreeNodeDataFinder"/> instance
	/// </summary>
	[MetadataAttribute, AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public sealed class ExportFileTreeNodeDataFinderAttribute : ExportAttribute, IFileTreeNodeDataFinderMetadata {
		/// <summary>Constructor</summary>
		public ExportFileTreeNodeDataFinderAttribute()
			: base(typeof(IFileTreeNodeDataFinder)) {
		}

		/// <summary>
		/// Order of this instance
		/// </summary>
		public double Order { get; set; }
	}
}