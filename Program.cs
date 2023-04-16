using System.Collections.Generic;
using System.Linq;
using static System.Console;

internal class Program
{
    class Player
    {
        public byte Card = 0;
        public byte Ljun = 0;
        public byte Sjun = 0;
    }

    static void Main()
    {
        string[] rl = ReadLine().Split( ' ' );
        byte ba = 0;
        byte jun = 1;
        var l = new List<Player>( rl.Length );

        foreach( byte i in Enumerable.Range( 0, rl.Length ) ) {
            var p = new Player();

            switch( rl[i] ) {
            case "J":
                p.Card = 11;
                break;
            case "Q":
                p.Card = 12;
                break;
            case "K":
                p.Card = 13;
                break;
            case "A":
                p.Card = 14;
                break;
            case "2":
                p.Card = 15;
                break;
            default:
                p.Card = byte.Parse( rl[i] );
                break;
            }
            p.Ljun = 0;
            p.Sjun = i;
            l.Add( p );
        }
        while( true ) {
            var t = new List<Player>();

            foreach( var i in Enumerable.Range( 0, rl.Length ) ) {
                if( ba < l[i].Card ) {
                    ba = l[i].Card;
                    l[i].Card = 0;
                    l[i].Ljun = jun;
                    jun++;
                    if( rl.Length < jun ) {
                        l = l.OrderBy( x => x.Sjun ).ToList();
                        foreach( var j in Enumerable.Range( 0, rl.Length ) ) {
                            WriteLine( string.Join( "\n", l[j].Ljun ) );
                        }
                        return;
                    }
                    t.Add( l[i] );
                    l.RemoveRange( 0, t.Count );
                    l.AddRange( t );
                    if( ba == 15 ) {
                        ba = 0;
                    }
                    break;
                } else {
                    t.Add( l[i] );
                    if( rl.Length <= t.Count ) {
                        ba = 0;
                    }
                }
            }
        }
    }
}