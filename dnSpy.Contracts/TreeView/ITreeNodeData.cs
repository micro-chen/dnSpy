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
using System.Collections.Generic;
using dnSpy.Contracts.Images;

namespace dnSpy.Contracts.TreeView {
	/// <summary>
	/// User data stored in a <see cref="ITreeNode"/>
	/// </summary>
	public interface ITreeNodeData {
		/// <summary>
		/// Guid of this data
		/// </summary>
		Guid Guid { get; }

		/// <summary>
		/// Group or null
		/// </summary>
		ITreeNodeGroup TreeNodeGroup { get; }

		/// <summary>
		/// Gets the data shown in the UI
		/// </summary>
		object Text { get; }

		/// <summary>
		/// Gets the data shown in a tooltip
		/// </summary>
		object ToolTip { get; }

		/// <summary>
		/// Icon
		/// </summary>
		ImageReference Icon { get; }

		/// <summary>
		/// Expanded icon or null to use <see cref="Icon"/>
		/// </summary>
		ImageReference? ExpandedIcon { get; }

		/// <summary>
		/// true if single clicking on a node expands all its children
		/// </summary>
		bool SingleClickExpandsChildren { get; }

		/// <summary>
		/// Returns true if the expander should be shown
		/// </summary>
		/// <param name="defaultValue">Default value</param>
		/// <returns></returns>
		bool ShowExpander(bool defaultValue);

		/// <summary>
		/// Gets the <see cref="ITreeNode"/> owner instance. Only the tree view may write to this
		/// property.
		/// </summary>
		ITreeNode TreeNode { get; set; }

		/// <summary>
		/// Called when it's time to create its children
		/// </summary>
		/// <returns></returns>
		IEnumerable<ITreeNodeData> CreateChildren();

		/// <summary>
		/// Called after <see cref="TreeNode"/> has been set.
		/// </summary>
		void Initialize();
	}
}