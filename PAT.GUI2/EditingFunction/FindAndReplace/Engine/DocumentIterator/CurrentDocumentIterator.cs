﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision: 2313 $</version>
// </file>

using System;
using ICSharpCode.SharpDevelop.DefaultEditor.Gui.Editor;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.TextEditor;
using PAT.GUI.Docking;


namespace SearchAndReplace
{
	public class CurrentDocumentIterator : IDocumentIterator
	{
		bool      didRead = false;
		
		public CurrentDocumentIterator()
		{
			Reset();
		}

        public string CurrentFileName
        {
            get
            {
                if (!SearchReplaceUtilities.IsTextAreaSelected)
                {
                    return null;
                }
                EditorTabItem textEditor = SearchReplaceUtilities.GetActiveTextEditorTab();

                return textEditor.PrimaryFileName;
            }
        }
		
		public ProvidedDocumentInformation Current {
			get {
				if (!SearchReplaceUtilities.IsTextAreaSelected) {
					return null;
				}
                TextEditorControl textEditor = SearchReplaceUtilities.GetActiveTextEditor();
				return new ProvidedDocumentInformation(textEditor.Document, CurrentFileName, textEditor.ActiveTextAreaControl);
			}
		}
			
		public bool MoveForward() 
		{
			if (!SearchReplaceUtilities.IsTextAreaSelected) {
				return false;
			}
			if (didRead) {
				return false;
			}
			didRead = true;
			
			return true;
		}
		
		public bool MoveBackward()
		{
			return MoveForward();
		}
		
		public void Reset() 
		{
			didRead = false;
		}
	}
}
