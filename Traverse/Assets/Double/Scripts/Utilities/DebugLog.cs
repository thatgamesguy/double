using UnityEngine;
using UnityEngine.UI;
using System.Text;


    /// <summary>
    /// Shows debug messages on screen for test purposes.
    /// </summary>
    [RequireComponent( typeof( Text ) )]
    public class DebugLog : Singleton<DebugLog>
    {
        /// <summary>
        /// Enable to show debug messages.
        /// </summary>
		public bool shouldShowDebug = false;
        public int numOfLinesToShow = 21;

        private Text m_Text;
        private string[] m_Lines;
        private int currentLine;

        void Awake()
        {
            m_Text = GetComponent<Text>();

            m_Lines = new string[numOfLinesToShow];

            if (!shouldShowDebug)
            {
                m_Text.enabled = false;
            }

        } 

	/// <summary>
	/// Apends text to the log.
	/// </summary>
	/// <param name="text">Text.</param>
        public void ApendLog( string text )
        {
			if( !shouldShowDebug )
			{
				return;
			}

            currentLine = ( currentLine + 1 ) % numOfLinesToShow;

            if( currentLine == 0 )
            {
                ClearList();
            }

            m_Lines[ currentLine ] = text;

            RePopulateList();
        }

        private void RePopulateList()
        {
            StringBuilder sb = new StringBuilder();

            foreach( var l in m_Lines )
            {
                sb.AppendLine( l );
            }

            m_Text.text = sb.ToString();
        }

        private void ClearList()
        {
            for( int i = 0; i < m_Lines.Length; i++ )
            {
                m_Lines[i] = "";
            }
        }

    }

