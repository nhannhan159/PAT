using System;
using System.Windows.Forms;

namespace PAT.Common.GUI
{
    public enum PATExample
    {
        DinningPhilosophers,
        DinningPhilosophersCLTS,
        DinningPhilosophersDeadLockFree,
        MilnersScheduler,
        ReadersWritersProblem,
        NeedhamSchroederProtocol,
        InterruptController,
        BridgeCrossingProblem,
        ChineseKlotskiProblem,
        LeaderElectionProtocol,
        LeaderElectionRing,
        TokenCirculationinRings,
        LeaderElectionOddRing,
        LeaderElectionInDirectTree,
        ReaderWriterRegister,
        ReaderWriterRegisterMoreReader,
        PetersonsAlgorithm,
        LLTSPCQCluster,
        LLTSPoliteEagerClientV2,
        LLTSPCQLinear,  
        LLTSPCQLiberal,
        LLTSPetersonsAlgorithm,//1
        LLTSCyclic,//2
        LLTSReadersWritersProblem,//2
        LLTSLamport,//2
        LLTSMCS,//2
        LLTSAnderson,//2       
        LLTSKrebs,//3
        LLTSPoliteEagerClients,
        LLTSStubbornSetExample,
        LLTSDijkstra,
        LLTSBakeryAlgorithm,
        LLTSDinningPhilosophers,
        LLTSPoliteGreedyDiners,
        MissionariesAndCannibals,
        WolfGoatCabbage,
        ConcurrentStackImplementation,
        ConcurrentStackLinearPointImplementation,
        ConcurrentQueueImplementation,
        MailboxProblem,
        SieveofEratosthenes,
        PaceMaker,
        BakeryAlgorithm,
        Dijkstra,
        SlidingGame,
        LightOff,
        KnightTour,
        PegGame,
        MineSweeper,
        HanoiTower,
        RubiksCube,
        ShuntingGame,
        LanguageFeature,
        ChannelOperators,
        CSharpLibrary,
        SynchronousChannelArray1,
        SynchronousChannelArray2,
        LiftSystem,
        KeylessCarSystem,
        HadoopArchitecture,
        ParameterizedReaderWriter,
        ParameterizedKValuedRegister,
        ParameterizedLeaderElection,
        ParameterizedStack,
        ParameterizedMetaLock,
        BuyerSeller,
        TravelAgent,
        //        ParallelExample,
        ParallelExample2,
        RoadAssistance,
        SNZI,
        LinkedList,
        OrientingUndirectedInRing,
        ConsensusWithCrashes,
        TwoHopColoringInRingsNonDeterministic,
        TwoHopColoringInRingsDeterministic,
        FischerProtocol,
        FischerProtocolTA,
        RailwayCrossing,
        RailwayControl,
        RailwayControlTA,
        PaceMakerTimed,
        LightControlSystem,
        ABP,
        ABPTimed,
        TPCP,
        ProbabilityExample1,
        ProbabilityExample2,
        PZ82MutualExclusion,
        RabinMutualExclution,
        GamblerProblem,
        CSMACD,
        CSMACD_RTS,
        CSMACD_TA,
        /*Added By Wang Ting*/
        BoxSorterUnit,
        TwoDoors,
        Lynch_mahata,
        TTAProtocal,
        /*Added By Wang Ting*/
        FDDI,
        ConsensusProb,
        MontyHallProblem,
        BSS,
        ESS,
        BSS3,
        BitT,
        MultiLifts,
        MultiLiftsPRTS,
        MultiLiftsRTS,
        ProbDinningPhil,
        DBMTesting,
        TelecommunicationServiceSystem,
        LiftingTruckSystem,
        FlashMemoryDeviceDriver,
        DrivingPhilosopher,
        SSL,
        //NESC Example: Sensor network examples
        NESCBlink,
        NESCRadioSenseToLeds,
        NESCTest,
        //NESCBlinkConfig,
        NESCBlinkTask,
        NESCBlinkToRadio,
        //NESCPowerup,
        NESCRadioCountToLeds,
        NESCSense,
        NESCTrickle,
        NESCMultihopOscilloscope,
        NESCTrafficLights,
        NESCAntiTheft,
        NESCTestNetwork,
        NESCTrickleNew,
        NESCTestFanInFanOut,
        NESCLeaderElectionWtTimer,
        NESCTrickleWtTimer,
        NESCTestDissemination,
        NESCKeyChain,
        NESCMutesla,
        //MDL Example: State Flow examples
        MDLAlarmController,
        MDLNewAlarmController,
        MDLShiftLogic,
        MDLFuelControl,
        MDLStopwatch,
        MDLSB,
        ORCMetronome,
        ORCConcQuickSort,
        ORCReaderWriterProblem,
        ORCAirlineAgent,
        ORCNRSDeadlockExample,
        ORCNRSCycleExample,
        ORCAuctionManagement,
        ORCAuctionManagementNRS,
        BPELTravelBookingService,
        BPELComputerPurchasingService,
        BPELStockMarketIndicesService,
        BPELPick_OnMessage,
        BPELWhile,
        BPELIfElse,
        BPELAssignment,
        BPELSynchronousCommunication,
        BPELASynchronousCommunication,
        Needham_Schroeder_protocol,
        Andrew_Secure_RPC_protocol,
        Denning_Sacco_shared_key_protocol,
        Lowe_modified_Denning_Sacco_shared_key_protocol,
        Needham_Schroeder_Timed_protocol,
        FixedNeedham_Schroeder_protocol,
        Wide_Mouthed_Frog_protocol,
        Fujioka_protocol,
        Okamoto_protocol,
        Lee_protocol,
        Semaphore,
        Tacas,
        //
        //PAR
        //
        ExRTSS,
        ParFischerProtocol,
        JobShop,
        TrainAHV93,
        ParTrainCrossing,
        //***********************
        //Start of BEEM Database
        //***********************
        BRP,
        BRP2,
        Collision,
        IProtocol,
        LeaderFilters,
        LeaderFiltersUnbounded,
        MCS,
        Peterson,
        Sorter,
        Resistance,
        Fischer,
        Lamport,
        Cambridge,
        Telephony,
        TelephonyE,
        Traingate,
        Exit,
        Gear,
        Protocols0,
        Protocols1,
        Protocols2,
        Adding,
        Bridge,
        Frogs,
        Hanoi,
        Loyd,
        Peg_solitaire,
        Pouring,
        Rushhour,
        Sokoban,
        Plc,
        Elevator_planning,
        Krebs,
        Schedule_world,
        Bopdp,
        Elevator,
        Lifts,
        Production_cell,
        Elevator2,
        Lup,
        Blocks,
        Anderson,
        At,
        Lamport_Nonatomic,
        /// <summary>
        /// Add By Li Li
        /// </summary>
        Lann,
        Szymanski,
        Extinction,
        Firewire_tree,
        Leader_election,
        Msmie,
        Public_subscribe,
        Synapse,
        //***********************
        //End of BEEM Database
        //***********************
        RINGING,
        //***********************
        //Start of Security Protocol Module
        //***********************
        HandshakeProtocol,
        NeedhamSchroederPK,
        VoteProtocol,
        EKEProtocol,
        OtwayReesProtocol,
        //***********************
        //Start of Security Protocol Module
        //***********************
        TwoStates,
        //CLTS
        InputOutput,
        ServerClient,
        //PROVERIF
        PV_FACEBOOK_CONNECT_SAMPLE,
        PV_SIM_DENNING_SACCO_SAMPLE,
        PV_DENNING_SACCO_SAMPLE,
        PV_DIFFIE_HELLMAN_SAMPLE,

        //UML Examples
        SimpleATMExample,
        //ATMExample,
        BankATMExample,
        //BankATMwithVariablesExample,
        RailCarOriginalExample,
        RailCarModifiedExample,
        TollGateExample,
        DiningPhilosopherUML2Example,
        DiningPhilosopherUML3Example,
        DiningPhilosopherUML4Example,
        DiningPhilosopherUML5Example,
        DiningPhilosopherUML6Example,
        DiningPhilosopherUML7Example,
        NoDiscription
    }

    public partial class ExampleForm : Form
    {
        public int Number
        {
            get { return (int)NUP_Number.Value; }
        }

        public int SizeNumber
        {
            get { return (int)NUP_Size.Value; }
        }

        public int ThirdNumber
        {
            get { return (int)this.NUP_Third.Value; }
        }

        public bool IsFair
        {
            get { return RadioButton_WL.Checked; }
        }

        public bool isOptimal
        {
            get { return RadioButton_SL.Checked; }
        }

        public bool IsAllFair
        {
            get { return RadioButton_AllFair.Checked; }
        }

        public bool HasThink
        {
            get { return CheckBox_HasThink.Checked; }
        }

        public bool IsLiveEvent
        {
            get { return RadioButton_LiveEvent.Checked; }
        }

        public bool isFairEvent
        {
            get { return RadioButton_FairEvent.Checked; }
        }

        public bool OptimizedForBDD
        {
            get { return CheckBox_BDDSpecific.Checked; }
        }

        public ExampleForm(PATExample example)
        {
            InitializeComponent();

            switch (example)
            {
                case PATExample.DinningPhilosophers:
                    this.Text = "Dinning Philosophers";
                    this.TextBox_Description.Text = "In 1971, Edsger Dijkstra set an examination question on a synchronization problem where five computers competed for access to five shared tape drive peripherals. Soon afterwards the problem was retold by Tony Hoare as the dining philosophers' problem. The problem is summarized as N philosophers sitting around a round table.\r\n\r\nThe five philosophers sit at a circular table with a large bowl of spaghetti in the center. A fork is placed in between each philosopher, and as such, each philosopher has one fork to his or her left and one fork to his or her right. As spaghetti is difficult to serve and eat with a single fork, it is assumed that a philosopher must eat with two forks. The philosopher can only use the fork on his or her immediate left or right. It is further assumed that the philosophers are so stubborn that a philosopher only put down the forks after eating.\r\n\r\nThere are several interesting problems. One is a dangerous possibility of deadlock when every philosopher holds a left fork and waits perpetually for a right fork. The other is starvation. A philosopher may starve for different reasons, e.g., system deadlock, greedy neighbor, etc.";
                    this.Panel_EventType.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;


                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Deadlock Free";
                    this.CheckBox_HasThink.Checked = false;
                    this.toolTip1.Active = false;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.DinningPhilosophersDeadLockFree:
                    this.Text = "Dinning Philosophers (Deadlock Free)";
                    this.TextBox_Description.Text = "In 1971, Edsger Dijkstra set an examination question on a synchronization problem where five computers competed for access to five shared tape drive peripherals. Soon afterwards the problem was retold by Tony Hoare as the dining philosophers' problem. The problem is summarized as N philosophers sitting around a round table.\r\n\r\nThe five philosophers sit at a circular table with a large bowl of spaghetti in the center. A fork is placed in between each philosopher, and as such, each philosopher has one fork to his or her left and one fork to his or her right. As spaghetti is difficult to serve and eat with a single fork, it is assumed that a philosopher must eat with two forks. The philosopher can only use the fork on his or her immediate left or right. It is further assumed that the philosophers are so stubborn that a philosopher only put down the forks after eating.\r\n\r\nThere are several interesting problems. One is a dangerous possibility of deadlock when every philosopher holds a left fork and waits perpetually for a right fork. The other is starvation. A philosopher may starve for different reasons, e.g., system deadlock, greedy neighbor, etc.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.MilnersScheduler:
                    this.Text = "Milner's Scheduler";
                    this.TextBox_Description.Text = "This scheduling algorithm is described by Milner in \"Communication and Concurrency, 1989\". There are N processes, which are activated in a cyclic manner, i.e., process i activates process i+1 and after process n process 1 is activated again. Moreover, a process may never be re-activated before it has terminated. The scheduler is built from n cyclers who are positioned in a ring. The first cycler plays a special role as it starts up the system. This model is perfect demonstration of the partial order reduction techniques for model checking.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 10;
                    RadioButton_SL.Checked = true;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.ReadersWritersProblem:
                    this.Text = "Readers-Writers Problem";
                    this.TextBox_Description.Text = "In computer science, the readers-writers problems are examples of a common computing problem in concurrency. The problem deals with situations in which many threads must access the same shared memory at one time, some reading and some writing, with the natural constraint that no process may access the share for reading or writing while another process is in the act of writing to it. In particular, it is allowed for two readers to access the share at the same time. In this model, a controller is used to guarantee the correct coordination among multiple readers/writers.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 10;
                    RadioButton_SL.Checked = true;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.NeedhamSchroederProtocol:
                    this.Text = "Needham-Schroeder Public Key Authentication Protocol";
                    this.TextBox_Description.Text = "The Needham-Schroeder Public Key Protocol is a well known authentication protocol that dates back to 1978. It aims to establish mutual authentication between an initiator A and a responder B, after which some session involving the exchange of messages between A and B can take place. It is based on public key cryptography i.e. RSA and aims to establish mutual authentication between two parties communicating over an unsecure network connection. Messages are encrypted using the recipient's public key and only the recipient who holds the private key can decrypt the messages to learn its contents. We denote messages encrypted with some public key as {x,y}PK{Z} with x and y being the data items of the encrypted message and PK(Z) being the public key of the recipient Z. Private or secret keys are denoted as SK and are used for both decryption and digitally signing messages to ensure message integrity.\r\n\r\nLowe was the first to demonstrate how formal specification techniques can be used to verify the security properties of cryptographic protocols. In his seminal 1995 paper, Lowe announced the discovery of a previously unknown man-in-the-middle attack on the Needham-Schroeder public key authentication protocol. The Needham-Schroeder protocol forms the basis of the widely-used Kerberos protocol. Before Lowe's announcement the Needham-Schroeder protocol had been subjected to various verication exercises and real-world use and was deemed as secure for 17 years!\r\n\r\nIn this example, we demonstrate both the original version of the protocol and fixed version. We acknowledge that this example was originally created by Bai Shuyong and Pan Xiangrui in a course project in April, 2009.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.RadioButton_SL.Text = "Original Protocol";
                    this.toolTip1.SetToolTip(RadioButton_SL, "Original Protocol, which has the security flaw.");
                    this.RadioButton_WL.Text = "Fixed Protocol";
                    this.toolTip1.SetToolTip(RadioButton_WL, "Fixed Protocol, which has no security flaw.");
                    Label_To.Visible = false;
                    //NUP_Number.Minimum = 1;
                    //NUP_Number.Maximum = 10;
                    //this.NUP_Number.Value = 1;
                    //Label_To.Text = "Number of Initiator";
                    //this.NUP_Size.Minimum = 1;
                    //this.NUP_Size.Maximum = 10;
                    //this.NUP_Size.Value = 1;
                    //this.NUP_Size.Visible = true;
                    //CheckBox_HasThink.Visible = true;
                    //CheckBox_HasThink.Text = "Number of Responder";
                    RadioButton_SL.Checked = true;
                    break;
                case PATExample.InterruptController:
                    this.Text = "Interrupt Controller";
                    this.TextBox_Description.Text = "This model is based on the example of Section 2 in Priorities in Process Algebras, by Rance Cleveland and Matthew Hennesy (Information and Computation, 1990). \r\n\r\nThe interrupt controller INT should communicate 'i' whenever possible, so that C cannot receive 'up' or 'down' after INT has received 'shut_down'.\r\n\r\nUncomment one of the priority specifications to make the model work, by using channel priorities (end of these declarations), or process priorities (system declaration).";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    Label_To.Text = "Counter Modulo";
                    this.toolTip1.SetToolTip(Label_To, "Counter Modulo");
                    this.NUP_Number.Value = 16;
                    break;
                case PATExample.BridgeCrossingProblem:
                    this.Text = "Bridge Crossing Problem";
                    this.TextBox_Description.Text = "All four people start out on the southern side of the bridge, namely the king, queen, a young lady and a knight. The goal is for everyone to arrive at the castle north of the bridge before the time runs out. The bridge can hold at most two people at a time and they must be carrying the torch when crossing the bridge. The king needs 5 minutes to cross, the queen 10 minutes, the lady 2 minutes and the night 1 minutes.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    Label_To.Text = "Maximum Time Allowed";
                    this.toolTip1.SetToolTip(Label_To, "Maximum Time Allowed");
                    this.NUP_Number.Value = 17;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.ChineseKlotskiProblem:
                    this.Text = "Hua Rong Dao (Chinese Variation of Klotski Problem )";
                    this.TextBox_Description.Text =
                        "Klotski is a whole group of similar sliding block puzzles where the aims are to move a specific block to some predefined location. " +
                        "Hua Rong Dao is the Chinese variation, featuring an old legendary during Battle of Red Cliffs in the 13th year of Jian An in the East Han Dynasty 208AD-- a well-known battle in Chinese history. " +
                        "The legendary: Cao Cao was defeated in this battle, and escaped to Hua Rong Dao, in which he encountered Guan Yu. Because Guan Yu remembered Cao Cao treated him well during old days despite he was a general of enemy of Cao Cao, " +
                        "Guan Yu spared Cao Cao's life. The largest block is named Cao Cao. The initial layout of this example is called  Bi Yi Heng Kong.";
                    this.RadioButton_WL.Text = "General";
                    this.RadioButton_SL.Text = "Optimal";
                    this.RadioButton_WL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.RadioButton_SL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Mr Yang Hang";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 11, 6)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    break;
                case PATExample.PetersonsAlgorithm:
                    this.Text = "Peterson's Algorithm";
                    this.TextBox_Description.Text = "Peterson's algorithm is a concurrent programming algorithm for mutual exclusion that allows two processes to share a single-use resource without conflict, using only shared memory for communication. It was formulated by Gary Peterson in 1981 at the University of Rochester. While Peterson's original formulation worked with only two processes, the algorithm can be generalised for more than two, as discussed in \"Operating Systems Review, January 1990 (Proof of a Mutual Exclusion Algorithm, M Hofri)\".";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    RadioButton_SL.Checked = true;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.LLTSPoliteEagerClientV2:
                    this.Text = "Polite Eager Client V2";
                    this.TextBox_Description.Text = "Polite Eager Client V2";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 8, 21)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "N");
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_HasThink.Visible = false;
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 20;
                    this.NUP_Number.Value = 2;
                    break;
                case PATExample.LLTSPCQLinear:
                    this.Text = "PCQ Linear";
                    this.TextBox_Description.Text = "PCQ Linear";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 8, 21)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "N");
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_HasThink.Visible = false;
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 20;
                    this.NUP_Number.Value = 2;
                    break;
                case PATExample.LLTSPCQLiberal:
                    this.Text = "PCQ Liberal";
                    this.TextBox_Description.Text = "PCQ Liberal";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 8, 21)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "N");
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_HasThink.Visible = false;
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 20;
                    this.NUP_Number.Value = 2;
                    break;
                case PATExample.LLTSPetersonsAlgorithm:
                    this.Text = "Peterson's Algorithm";
                    this.TextBox_Description.Text = "Peterson's algorithm is a concurrent programming algorithm for mutual exclusion that allows two processes to share a single-use resource without conflict, using only shared memory for communication. It was formulated by Gary Peterson in 1981 at the University of Rochester. While Peterson's original formulation worked with only two processes, the algorithm can be generalised for more than two, as discussed in \"Operating Systems Review, January 1990 (Proof of a Mutual Exclusion Algorithm, M Hofri)\".";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    RadioButton_SL.Checked = true;
                    this.CheckBox_BDDSpecific.Visible = false;
                    break;
                case PATExample.LLTSCyclic:
                    this.Text = "Milner's cyclic scheduler";
                    this.TextBox_Description.Text = "The system describe a scheduler for N concurrent processes. The processes are scheduled in cyclic fashion so that the first process is reactivated after the Nth process has been activated." +
                                                   Environment.NewLine + "N: Number of the processes" +
                                                   Environment.NewLine + "ERROR: Presence of an (artifical) error (0/1)"; ;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 5, 13)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "N");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 20;
                    this.NUP_Number.Value = 8;


                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "ERROR";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "ERROR");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 1;
                    this.NUP_Size.Value = 0;


                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.LLTSStubbornSetExample:
                    this.Text = "Stubborn Set Example";
                    this.TextBox_Description.Text = "Description could be found on http://www.comp.nus.edu.sg/~pat/por/ under description of 'Example'.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Value = 1;

                    break;
                case PATExample.LLTSPoliteEagerClients:
                    this.Text = "Polite And Eager Clients";
                    this.TextBox_Description.Text = "The model works as follows: two kinds of clients seek access to a shared resource: polite and eager clients. Polite clients issue requests only when the request queue is empty, eager clients do not care. Each client has a number of times that it accesses the resource, after which the client shuts down. In addition, polite clients (but not eager clients) may be \"resurrected\".";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 15)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "Polite Clients";
                    this.toolTip1.SetToolTip(Label_To, "Polite Clients");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 20;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Eager Clients";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "Eager Clients");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 2;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Maximum = 20;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.LLTSPoliteGreedyDiners:
                    this.Text = "Polite And Greedy Diners";
                    this.TextBox_Description.Text = "";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 15)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "Polite Diners";
                    this.toolTip1.SetToolTip(Label_To, "Polite Diners");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 20;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Greedy Diners";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "Greedy Diners");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 2;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Maximum = 20;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.LLTSDijkstra:
                    this.Text = "Dijkstra's Mutual Exclusion Algorithm";
                    this.TextBox_Description.Text = "Dijkstra's Mutual Exclusion Algorithm";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Text = "The number of processes";
                    this.toolTip1.SetToolTip(Label_To, "The number of processes in the algorithm");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 10;
                    this.RadioButton_SL.Checked = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    break;
                case PATExample.LLTSBakeryAlgorithm:
                    this.Text = "Bakery Algorithm";
                    this.TextBox_Description.Text = "Lamport's bakery algorithm is a computer algorithm devised by computer scientist Dr. Leslie Lamport, which is intended to improve the safety in the usage of shared resources among multiple threads by means of mutual exclusion.";
                    this.CheckBox_HasThink.Text = "Maximum Ticket Bound";
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 2;
                    this.NUP_Size.Maximum = 200;
                    this.NUP_Size.Value = 4;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "The number of processes";
                    this.toolTip1.SetToolTip(Label_To, "The number of processes in the algorithm");
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 10;
                    this.NUP_Number.Value = 2;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    break;
                case PATExample.LLTSDinningPhilosophers:
                    this.Text = "Dinning Philosophers";
                    this.TextBox_Description.Text = "In 1971, Edsger Dijkstra set an examination question on a synchronization problem where five computers competed for access to five shared tape drive peripherals. Soon afterwards the problem was retold by Tony Hoare as the dining philosophers' problem. The problem is summarized as N philosophers sitting around a round table.\r\n\r\nThe five philosophers sit at a circular table with a large bowl of spaghetti in the center. A fork is placed in between each philosopher, and as such, each philosopher has one fork to his or her left and one fork to his or her right. As spaghetti is difficult to serve and eat with a single fork, it is assumed that a philosopher must eat with two forks. The philosopher can only use the fork on his or her immediate left or right. It is further assumed that the philosophers are so stubborn that a philosopher only put down the forks after eating.\r\n\r\nThere are several interesting problems. One is a dangerous possibility of deadlock when every philosopher holds a left fork and waits perpetually for a right fork. The other is starvation. A philosopher may starve for different reasons, e.g., system deadlock, greedy neighbor, etc.";
                    this.Panel_EventType.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;


                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Deadlock Free";
                    this.CheckBox_HasThink.Checked = false;
                    this.toolTip1.Active = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    break;
                case PATExample.LeaderElectionProtocol:
                    this.Text = "Leader Election in Complete Network Graphs";
                    this.TextBox_Description.Text = "This example models an leader-election algorithm for complete network graphs using a leader detector. Each node has a memory slot that can hold either a leader mark \"x\" or nothing \"-\" for a total of two states. Each node receives its current input true (T) or false (F) from the leader detector. A non-leader becomes a leader, when the leader detector signals the absence of a leader, and the responder is not a leader. When two leaders interact, the responder becomes a non-leader. Otherwise, no state change occurs.\r\n\r\nThe algorithm can be formalled described by 3 pattern rules which are matched against the state and input of the initiator and responder, respectively. If the match succeeds, the states of the two interacting nodes are replaced by the respective states on the right side of the rule. In performing the match, \"*\" is a \"don't care\" symbol that always matches the slot or the input. On the right hand side, \"*\" specifies that the contents of the corresponding slot do not change. If no explicit rules match, a null transition in which neither node changes state is implied.\r\n\r\nRule 1. ((x,*), (x,*)) -> ((x), (-)) \r\nRule 2. ((-,F), (-,*)) -> ((x), (-))\r\nRule 3. ((-,T), (-,*)) -> ((-), (-))\r\n\r\nSee paper \"M. J. Fischer and H. Jiang. Self-stabilizing leader election in networks of finite-state anonymous agents. In Proc. 10th Conference on Principles of Distributed Systems, volume 4305 of LNCS, pages 395-409. Springer, 2006.\"";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    RadioButton_SL.Checked = true;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.LeaderElectionRing:
                    this.Text = "Leader Election in Ring";
                    this.TextBox_Description.Text = "This example models an leader-election algorithm for network rings using a leader detector. For details, refer to the paper \"M. J. Fischer and H. Jiang. Self-stabilizing leader election in networks of finite-state anonymous agents. In Proc. 10th Conference on Principles of Distributed Systems, volume 4305 of LNCS, pages 395-409. Springer, 2006.\"";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    RadioButton_SL.Checked = true;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.TokenCirculationinRings:
                    this.Text = "Token Circulation in Rings";
                    this.TextBox_Description.Text = "This example models an leader-election algorithm for network rings with token circulations. For details, refer to the paper \"M. J. Fischer and H. Jiang. Self-stabilizing leader election in networks of finite-state anonymous agents. In Proc. 10th Conference on Principles of Distributed Systems, volume 4305 of LNCS, pages 395-409. Springer, 2006.\"";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    RadioButton_SL.Checked = true;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.LeaderElectionOddRing:
                    this.Text = "Leader Election in Odd Size Ring";
                    this.TextBox_Description.Text = "This example models an leader-election algorithm for network rings of odd size. For details, refer to the paper \"Hong Jiang. Distributed Systems of Simple Interacting Agents , Ph.D. Dissertation, Yale University , 2007.\"";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Increment = 2;
                    RadioButton_SL.Checked = true;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.LeaderElectionInDirectTree:
                    this.Text = "Self-stabilizing Leader Election in (Directed) Rooted Trees";
                    this.TextBox_Description.Text = "This example models an leader-election algorithm for directed rooted tree of odd size. For details, refer to the paper \"Algorithm 5.1, Davide Canepa,Maria Gradinariu Potop-Butucaru: Stabilizing token schemes for population protocols CoRR abs/0806.3471, 2008.\"";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Increment = 2;
                    RadioButton_SL.Checked = true;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.OrientingUndirectedInRing:
                    this.Text = "Orienting Undirected In Ring";
                    this.TextBox_Description.Text = "It is possible to have a protocol that gives a sense of orientation to each node on an undirected ring[1]. After the orienting, (1) each node has exactly one predecessor and one successor, the predecessor and successor of a node are different; (2) for any two nodes u and v, u is the predecessor of v if and only if v is the successor of u, for any edge (u, v), either u is the predecessor of v or v is the predecessor of u. \r\n\r\nEach node u in a ring has three state components: color[u] encodes the color of node u, precolor[u] the color of its predecessor, and succolor[u] the color of its successor. Initially, all nodes are two-hop colored (array color satisfies the two-hop coloring property), precolor[u] and succolor[u] can have arbitrary values. The following description defines the interaction between an initiator u and a responder v. \r\n\r\n[1] D. Angluin, J. Aspnes, M. J. Fischer, and H. Jiang. Selfstabilizing population protocols. ACM Transactions on Autonomous and Adaptive Systems, 3(4):643644, 2008.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Increment = 1;
                    this.NUP_Number.Maximum = 6;
                    RadioButton_SL.Checked = true;
                    this.Label_To.Text = "Number of Nodes";
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.ConsensusWithCrashes:
                    this.Text = "Consensus With Crashes";
                    this.TextBox_Description.Text = "Consensus With Crashes Example";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Increment = 1;
                    RadioButton_SL.Checked = true;
                    this.Label_To.Text = "Number of Nodes";
                    break;
                case PATExample.TwoHopColoringInRingsDeterministic:
                    this.Text = "Two Hop Coloring In Rings - Deterministic";
                    this.TextBox_Description.Text = "A protocol to make nodes to recognize their neighbors in a ring is presented in [1]. In fact, it is a general algorithm that enables each node in a degree-bounded graph to distinguish between its neighbors. The graph is colored such that any two nodes adjacent to the same node have different colors. More precisely, for each node v, if u and w are distinct neighbors of v, then u and w must have different colors. (u, w) is called a \"two-hop\" pair. In the current paper, we restrict ourselves to rings, and three colors suffice the purpose (see [1]).\r\n\r\nEach node u in a ring has two state components, color[u] encodes the color of node u and F[u] is a bit array, indexed by colors. Initially, color[u] and F[u] can have arbitrary values. The following description defines the interaction between an initiator u and a responder v. \r\n\r\nif F[u][color[v]] != F[v][color[u]] then\r\n     color[u] <- (color[u]+r[u]) % C\r\n     F[u][color[v]]=F[v][color[u]]\r\nelse F[u][color[v]]= neg(F[u][color[v]])\r\n     F[v][color[u]]= neg{F[v][color[u]]}\r\n      r[u] <- neg r[u]\r\n\r\nInstead of nondeterministically assigning all possible colors to the initiator u, its color is updated as color[u] <- (color[u]+r[u]) mod C. The additional state component r[u] is a local bit for node u that flits whenever u acts as the initiator of an interaction.\r\n\r\n[1] D. Angluin, J. Aspnes, M. J. Fischer, and H. Jiang. Selfstabilizing population protocols. ACM Transactions on Autonomous and Adaptive Systems, 3(4):643644, 2008.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Increment = 1;
                    RadioButton_SL.Checked = true;
                    this.Label_To.Text = "Number of Nodes";
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;

                case PATExample.TwoHopColoringInRingsNonDeterministic:
                    this.Text = "Two Hop Coloring In Rings - Non Deterministic";
                    this.TextBox_Description.Text = "A protocol to make nodes to recognize their neighbors in a ring is presented in [1]. In fact, it is a general algorithm that enables each node in a degree-bounded graph to distinguish between its neighbors. The graph is colored such that any two nodes adjacent to the same node have different colors. More precisely, for each node v, if u and w are distinct neighbors of v, then u and w must have different colors. (u, w) is called a \"two-hop\" pair. In the current paper, we restrict ourselves to rings, and three colors suffice the purpose (see [1]).\r\n\r\nEach node u in a ring has two state components, color[u] encodes the color of node u and F[u] is a bit array, indexed by colors. Initially, color[u] and F[u] can have arbitrary values. The following description defines the interaction between an initiator u and a responder v. \r\n\r\nif F[u][color[v]] != F[v][color[u]]  then \r\n    color[u] <- color'[u]\r\n    F[u][color[v]] =F[v][color[u]]\r\nelse\r\n    F[u][color[v]] = neg(F[u][color[v]])\r\n    F[v][color[u]] = neg(F[v][color[u]])\r\n\r\nOne edge (or interaction) (u,v) is synchronized if F[u][color[v]] = F[v][color[u]], then these two nodes do not change their color but flip their bits (F[u][color[v]] and F[v][color[u]]). On the other hand, node u is nondeterministically recolored, and it copies F[v][color[u]] of node v as its bit F[u][color[v]]. The statement color[u] <- color'[u] means one of the three possible colors is nondeterministically assigned as the new color of u.\r\n\r\n[1] D. Angluin, J. Aspnes, M. J. Fischer, and H. Jiang. Selfstabilizing population protocols. ACM Transactions on Autonomous and Adaptive Systems, 3(4):643644, 2008.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Increment = 1;
                    RadioButton_SL.Checked = true;
                    this.Label_To.Text = "Number of Nodes";
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.ReaderWriterRegister:
                    this.Text = "Multi-valued Register Simulation";
                    this.TextBox_Description.Text = "This example describes how to simulate a K-valued single-writer single-reader register from K binary single-writer single-reader registers for K >2. For details, refer to book \"Hagit Attiya, Jennifer Welch. Distributed Computing: Fundamentals, Simulations, and Advanced Topics, 2nd Edition. March 2004, ISBN: 978-0-471-45324-6\"";
                    this.CheckBox_HasThink.Visible = false;

                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Text = "Correct";
                    this.toolTip1.SetToolTip(RadioButton_WL, "Generate the correct model, where the linearizibility holds");
                    this.RadioButton_SL.Text = "Faulty";
                    this.toolTip1.SetToolTip(RadioButton_SL, "Generate the Faulty model, where the linearizibility does no hold");
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    this.RadioButton_AllFair.Text = "Explicit Events";
                    this.RadioButton_Partial.Text = "Tau Events";
                    this.RadioButton_WL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.RadioButton_SL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.toolTip1.SetToolTip(RadioButton_AllFair, "Use explicit events to make the model easy to understand");
                    this.toolTip1.SetToolTip(RadioButton_Partial, "Use tau events to make the model fast to check");
                    Label_To.Text = "K value";
                    break;
                case PATExample.MissionariesAndCannibals:
                    this.Text = "Missionaries and Cannibals";
                    this.TextBox_Description.Text = "In the missionaries and cannibals problem, three missionaries and three cannibals must cross a river using a boat which can carry at most two people, under the constraint that, for both banks, if there are missionaries present on the bank, they cannot be outnumbered by cannibals (if they were, the cannibals would eat the missionaries.) The boat cannot cross the river by itself with no people on board.\r\n\r\nStart bank: A \r\nOther bank: B\r\n\r\nIn this program, there are 2 variables: missionary and cannibal which store the number of missionaries and cannibals in the bank A.";
                    this.CheckBox_HasThink.Visible = true;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Text = "Number of Missionaries";
                    this.toolTip1.SetToolTip(Label_To, "Number of Missionaries");
                    //--------------------------------
                    //Label lable_capacity = new Label();
                    //lable_capacity.Text = "Capacity of the boat";
                    //lable_capacity.Left = 420;
                    //lable_capacity.Top = 52;
                    //lable_capacity.AutoSize = true;
                    //this.Controls.Add(lable_capacity);
                    CheckBox_HasThink.Text = "Capacity of the boat";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "the number of people that the boat can hold");
                    this.NUP_Size.Value = 2;
                    this.NUP_Size.Minimum = 2;
                    this.NUP_Size.Maximum = 4;
                    this.NUP_Size.Visible = true;
                    //--------------------------------
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.WolfGoatCabbage:
                    this.Text = "Wolf Goat Cabbage Problem";
                    this.TextBox_Description.Text = "A farmer with his wolf, goat and cabbage come to the edge of a river they wish to cross. There is a boat at the river's edge. But, of course, only the farmer can row it. The boat also can carry only two things (including the rower) at a time. If the wolf is ever left alone with the goat, the wolf will eat the goat; similarly, if the goat is left alone with the cabbage, the goat will eat the cabbage. Devise a sequence of crossings of the river so that all four characters arrive safely on the other side of the river. \r\n\r\nStart bank: A\r\nOther bank: B\r\n\r\nIn this program, there are 4 variables: farmer, wolf, goat and cabbage to know which bank farmer, wolf, goat and cabbage are staying, respectively 0 is in bank A, and 1 is in bank B.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Text = "Number of Missionaries and Cannibals";
                    this.toolTip1.SetToolTip(Label_To, "Number of Missionaries and Cannibals");
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.RubiksCube:
                    this.Text = "Rubik's Cube Game";
                    this.TextBox_Description.Text = "The Rubik's Cube is a 3-D mechanical puzzle invented in 1974 by Hungarian sculptor and professor of architecture Ernő Rubik. Originally called the \"Magic Cube\", the puzzle was licensed by Rubik to be sold by Ideal Toys in 1980 and won the German Game of the Year special award for Best Puzzle that year. As of January 2009, 350 million cubes have sold worldwide making it the world's top-selling puzzle game. It is widely considered to be the world's best-selling toy. \r\n\r\n In a classic Rubik's Cube, each of the six faces is covered by 9 stickers, among six solid colours (traditionally white, red, blue, orange, green, and yellow). A pivot mechanism enables each face to turn independently, thus mixing up the colours. For the puzzle to be solved, each face must be a solid colour.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    break;
                case PATExample.ShuntingGame:
                    this.Text = "Shunting Game";
                    this.TextBox_Description.Text = "Shunting game has a board with one black piece (the shunter), n white piece and n cells marked with cross. The goal of the shunting game is to move the shunter to push the white piece around until all white pieces are in cells marks with cross. A move consists of black piece (the shunter) moving one position either vertically or horizontally provided either\r\n\r\n1) the position moved to is empty\r\n2) the position moved to is occupied by a white piece but the position beyond the white piece is empty, in which case the white piece id pushed into the empty position. \r\n\r\nThe shunter can not push two white pieces at the same time. ";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    this.RadioButton_WL.Text = "Explicit Model Board";
                    this.RadioButton_SL.Text = "Using Board Lib";
                    this.RadioButton_WL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.RadioButton_SL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.toolTip1.SetToolTip(RadioButton_SL, "Model the board using C# library, which gives better performance.");
                    this.toolTip1.SetToolTip(RadioButton_WL, "Model the board explicitly in the system.");
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Dr Sun Jun";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2009, 12, 2)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;

                case PATExample.ConcurrentStackImplementation:
                    this.Text = "Concurrent Stack Implementation";
                    this.TextBox_Description.Text = "For details, please look at paper \"Treiber, R.K.: Systems programming: Coping with parallelism. Technical Report RJ 5118, IBM Almaden Research Center (1986)\"";

                    this.Panel_EventType.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.RadioButton_WL.Text = "Tau Events";
                    this.RadioButton_SL.Text = "Explicit Events";
                    this.RadioButton_WL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.RadioButton_SL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.toolTip1.SetToolTip(RadioButton_WL, "Use explicit events to make the model easy to understand");
                    this.toolTip1.SetToolTip(RadioButton_SL, "Use tau events to make the model fast to check");
                    NUP_Size.Visible = true;
                    CheckBox_HasThink.Text = "Stack Length";
                    break;
                case PATExample.ConcurrentStackLinearPointImplementation:
                    this.Text = "Concurrent Stack Linearization Point Implementation";
                    this.TextBox_Description.Text = "For details, please look at paper \"Treiber, R.K.: Systems programming: Coping with parallelism. Technical Report RJ 5118, IBM Almaden Research Center (1986)\"";

                    this.Panel_EventType.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    //this.RadioButton_WL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    //this.RadioButton_SL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    //this.toolTip1.SetToolTip(RadioButton_WL, "Use explicit events to make the model easy to understand");
                    //this.toolTip1.SetToolTip(RadioButton_SL, "Use tau events to make the model fast to check");
                    NUP_Size.Visible = true;
                    CheckBox_HasThink.Text = "Stack Length";
                    break;
                case PATExample.ConcurrentQueueImplementation:
                    this.Text = "Concurrent Queue Implementation";
                    this.TextBox_Description.Text = "For details, please look at paper \"Robert Colvin, Lindsay Groves, Formal verification of an array-based nonblocking queue, Engineering of Complex Computer Systems, 2005. ICECCS 2005. Proceedings. 10th IEEE International Conference on 16-20 June 2005.\"";

                    this.Panel_EventType.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.RadioButton_WL.Text = "Correct";
                    this.RadioButton_SL.Text = "Buggy";
                    this.RadioButton_WL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.RadioButton_SL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.toolTip1.SetToolTip(RadioButton_WL, "The corrected implementation of the queue example");
                    this.toolTip1.SetToolTip(RadioButton_SL, "The original buggy implementation");
                    NUP_Size.Visible = true;
                    CheckBox_HasThink.Text = "Queue Length";
                    break;
                case PATExample.MailboxProblem:
                    this.Text = "The Mailbox Problem";
                    this.TextBox_Description.Text = "This is a theoretical synchronization problem that arises from this setting, which we call the mailbox problem. From time to time, a postman (the device) places letters (requests) for a housewife (the processor) in a mailbox by the street.3 The mailbox has a flag that the wife can see from her house. She looks at the flag from time to time and, depending on what she sees, may decide to go to the mailbox to pick up its contents, perhaps changing the position of the flag. The wife and postman can leave notes for one another at the mailbox. (The notes cannot be read from the house.) We require a protocol to ensure that (i) the wife picks up every letter placed in the mailbox and (ii) the wife never goes to the mailbox when it is empty (corresponding to a spurious interrupt). The protocol cannot leave the wife or the postman stuck at the mailbox, regardless of what the other does. For example, if the wife and postman are both at the mailbox when the postman decides to take a nap, the wife need not remain at themailbox until the postmanwakes up.We do not require the wife to receive letters that are still in the sleeping postman's bag. However, we interpret condition (i) to require that she be able to receive mail left by the postman in previous visits to the mailbox without waiting for him to wake up. \n\nThe mailbox problem is an instance of a general class of problems called boundedsignaling problems. We give a general algorithm for any problem in this class. The algorithm is non-blocking but not wait-free. It is an open problem whether there are general wait-free algorithms in this case. \n\nFor details, please look at paper \"Marcos Aguilera, Eli Gafni and Leslie Lamport, The Mailbox Problem, DISC08 .\"";
                    Label_To.Text = "Number of operations:";
                    this.CheckBox_HasThink.Visible = false;
                    this.NUP_Size.Visible = false;

                    this.Panel_EventType.Visible = false;
                    //this.Panel_FairType.Visible = false;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.RadioButton_WL.Text = "Non-Blocking";
                    this.RadioButton_SL.Text = "Waitfree";
                    this.RadioButton_WL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.RadioButton_SL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.toolTip1.SetToolTip(RadioButton_WL, "The non-blocking version of the algorithm");
                    this.toolTip1.SetToolTip(RadioButton_SL, "The waitfree version of the algorithm");
                    this.RadioButton_AllFair.Text = "With Optimization";
                    this.RadioButton_Partial.Text = "No Optimization";
                    this.toolTip1.SetToolTip(RadioButton_AllFair, "");
                    this.toolTip1.SetToolTip(RadioButton_Partial, "");
                    break;
                case PATExample.ReaderWriterRegisterMoreReader:
                    this.Text = "Multi-valued Register Simulation with Multiple Readers";
                    this.TextBox_Description.Text = "This example describes how to simulate a K-valued single-writer multi-reader register from K binary single-writer multi-reader registers for K >2. For details, refer to book \"Hagit Attiya, Jennifer Welch. Distributed Computing: Fundamentals, Simulations, and Advanced Topics, 2nd Edition. March 2004, ISBN: 978-0-471-45324-6\"";
                    //this.CheckBox_HasThink.Visible = false;


                    this.Panel_EventType.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.RadioButton_WL.Text = "Correct";
                    this.toolTip1.SetToolTip(RadioButton_WL, "Generate the correct model, where the linearizibility holds");
                    this.RadioButton_SL.Text = "Faulty";
                    this.toolTip1.SetToolTip(RadioButton_SL, "Generate the Faulty model, where the linearizibility does no hold");
                    //this.RadioButton_WL.Visible = false;
                    //this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    //this.RadioButton_AllFair.Text = "Explicit Events";
                    //this.RadioButton_Partial.Text = "Tau Events";
                    //this.RadioButton_WL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    //this.RadioButton_SL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    //this.toolTip1.SetToolTip(RadioButton_AllFair, "Use explicit events to make the model easy to understand");
                    //this.toolTip1.SetToolTip(RadioButton_Partial, "Use tau events to make the model fast to check");
                    Label_To.Text = "K value";
                    NUP_Size.Visible = true;
                    CheckBox_HasThink.Text = "Number of Readers";
                    break;
                case PATExample.SieveofEratosthenes:
                    this.Text = "Sieve of Eratosthenes";
                    this.TextBox_Description.Text = "In mathematics, the Sieve of Eratosthenes is a simple, ancient algorithm for finding all prime numbers up to a specified integer. It was created by Eratosthenes, an ancient Greek mathematician. Wheel factorization is often applied on the list of integers to be checked for primality, before the Sieve of Eratosthenes is used, to increase the speed. By Wikipedia.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Text = "The biggest prime number";
                    this.toolTip1.SetToolTip(Label_To, "The biggest prime number");
                    this.NUP_Number.Value = 100;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 1000;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.PaceMaker:
                    this.Text = "Pace Maker";
                    this.TextBox_Description.Text = "A pacemaker is an electronic device used to treat patients who have symptoms caused by abnormally slow heartbeats. A pacemaker is capable of keeping track of the patient's heartbeats. If the patient's heart is beating too slowly, the pacemaker will generate electrical signals similar to the heart's natural signals, causing the heart to beat faster. The purpose of the pacemaker is to maintain heartbeats so that adequate oxygen and nutrients are delivered through the blood to the organs of the body. \r\n\r\n The pacemaker has several operating modes that address different malfunctions of the natural pacemaker. The operating modes of the device are classified using a code consisting of three or four characters. For the examples in this paper, the code elements are: chamber(s) paced (O for none, A for atrium, V for ventricle, D for both), chamber(s) sensed (same codes), response to sensing (O for none), response to sensing (O for none) and a final optional R to indicate the presence of rate modulation in response to the physical activity of the patient as measured by the accelerometer. X is a wildcard used to denote any letter (i.e. O, A, V or D). Thus DOO is an operating mode in which both chambers are paced but no chambers are sensed, and XXXR denotes all modes with rate modulation. In this model, we consider three operating modes of the pacemaker: AAO, AAT and DOO.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    break;
                case PATExample.BakeryAlgorithm:
                    this.Text = "Bakery Algorithm";
                    this.TextBox_Description.Text = "Lamport's bakery algorithm is a computer algorithm devised by computer scientist Dr. Leslie Lamport, which is intended to improve the safety in the usage of shared resources among multiple threads by means of mutual exclusion.";
                    this.CheckBox_HasThink.Text = "Maximum Ticket Bound";
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 4;
                    this.NUP_Size.Value = 4;
                    this.NUP_Size.Maximum = 200;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "The number of processes";
                    this.toolTip1.SetToolTip(Label_To, "The number of processes in the algorithm");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 10;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.Dijkstra:
                    this.Text = "Dijkstra's Mutual Exclusion Algorithm";
                    this.TextBox_Description.Text = "Dijkstra's Mutual Exclusion Algorithm";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Text = "The number of processes";
                    this.toolTip1.SetToolTip(Label_To, "The number of processes in the algorithm");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 10;
                    this.RadioButton_SL.Checked = true;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.SlidingGame:
                    this.Text = "Sliding Game";
                    this.TextBox_Description.Text = "The simple sliding game to move the pieces around to make them ordered as 1 to (n*n - 1).";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Board Size";
                    this.toolTip1.SetToolTip(Label_To, "Board Size");
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Maximum = 4;
                    this.RadioButton_WL.Text = "Default";
                    this.RadioButton_SL.Text = "With Move Cost";
                    this.RadioButton_WL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.RadioButton_SL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.toolTip1.SetToolTip(RadioButton_WL, "Default Sliding Game");
                    this.toolTip1.SetToolTip(RadioButton_SL, "Sliding Game with cost added during the move");
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.LightOff:
                    this.Text = "LightOff Game";
                    this.TextBox_Description.Text = "The simple LightOff game (available for iPhone).";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Board Size";
                    this.toolTip1.SetToolTip(Label_To, "Board Size");
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Maximum = 4;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    break;
                case PATExample.KnightTour:
                    this.Text = "The Knight Tour";
                    this.TextBox_Description.Text = "The Knight's Tour is a mathematical problem involving a knight on a chessboard. The knight is placed on the empty board and, moving according to the rules of chess, must visit each square exactly once. A knight's tour is called a closed tour if the knight ends on a square attacking the square from which it began (so that it may tour the board again immediately with the same path). Otherwise the tour is open. The exact number of open tours is still unknown. Creating a program to solve the knight's tour is a common problem given to computer science students.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Board Size";
                    this.toolTip1.SetToolTip(Label_To, "Board Size");
                    this.NUP_Number.Value = 5;
                    this.NUP_Number.Minimum = 4;
                    this.NUP_Number.Maximum = 50;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.PegGame:
                    this.Text = "Peg Game";
                    this.TextBox_Description.Text = "Peg Game is a board game for one player involving movement of pegs on a board with holes. Some sets use marbles in a board with indentations. The rule is to jump pegs by clicking and dragging an adjoining peg to the open hole on the other side. Each time a peg is jumped, it is automatically removed. You can only remove pegs by jumping them. The best solution is with this peg in the center. In this example, we provide 9 different settings.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Game Setting";
                    this.toolTip1.SetToolTip(Label_To, "Game Setting");
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Value = 1;
                    this.NUP_Number.Maximum = 9;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = true;

                    break;
                case PATExample.MineSweeper:
                    this.Text = "MineSweeper Game";
                    this.TextBox_Description.Text = "The Minesweeper is a fashionable and easy to learn computer game. The player is initially presented with a grid of undistinguished squares. Some randomly selected squares, unknown to the player, are designated to contain mines. The game is won when all mine-free squares are revealed. \r\n\r\nThe player can reveal a square by left-clicking it with a mouse. If a square containing a mine is revealed, the player loses the game. Otherwise, a digit is revealed in the square, indicating the number of adjacent squares that contain mines. In typical implementations, if this number is zero then the square appears blank, and the surrounding squares are automatically also revealed. By using logic, the player can in many instances use this information to deduce that certain other squares are mine-free, in which case they may be safely revealed, or mine-filled, in which they can be marked by right-clicking the square and indicated by a flag graphic.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    //this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Group";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 12, 22)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.HanoiTower:
                    this.Text = "Tower of Hanoi";
                    this.TextBox_Description.Text = "The Tower of Hanoi or Towers of Hanoi (also known as The Towers of Brahma) is a mathematical game or puzzle. It consists of three rods, and a number of disks of different sizes which can slide onto any rod. The puzzle starts with the disks neatly stacked in order of size on one rod, the smallest at the top, thus making a conical shape. \r\n\r\nThe objective of the puzzle is to move the entire stack to another rod, obeying the following rules: \r\nOnly one disk may be moved at a time. \r\nEach move consists of taking the upper disk from one of the pegs and sliding it onto another rod, on top of the other disks that may already be present on that rod. \r\nNo disk may be placed on top of a smaller disk.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Number of discs";
                    this.toolTip1.SetToolTip(Label_To, "Number of discs");
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 50;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    break;
                case PATExample.LiftSystem:
                    this.Text = "Mulitple Lift System";
                    this.TextBox_Description.Text = "A multiple lift system with several lifts, floors and users. The liveness property we want to check is whether there all the requests will be served. It turns out we need week fairness to proof this property.";
                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Number of lift";
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 2;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Maximum = 50;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Number of floors";
                    this.toolTip1.SetToolTip(Label_To, "Number of floors");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 50;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.Label_ThirdLabel.Visible = true;
                    this.NUP_Third.Visible = true;
                    break;
                case PATExample.KeylessCarSystem:
                    this.Text = "Keyless Car System";
                    this.TextBox_Description.Text = "One of the latest automotive technologies, push-button keyless system, allows you to start your car's engine without the hassle of key insertion and offers great convenience. \r\n\r\nPush-button keyless system allows owner with key-fob in her pocket to unlock the door when she is very near the car. The driver can slide behind the wheel, with the key-fob in her pocket (briefcase or purse or anywhere inside the car), she can push the start/stop button on the control panel. Shutting off the engine is just as hassle-free, and is accomplished by merely pressing the start/stop button. \r\n\r\nThese systems are designed so it is impossible to start the engine without the owner's key-fob and it cannot lock your key-fob inside the car because the system will sense it and prevent the user from locking them in.\r\n\r\nHowever, the keyless system can also surprise you as it may allow you to drive the car without key-fob. This has happened to Jin Song when his wife droped him to his office on the way to a shopping mall but the key-fob was in Jin Song's pocket. At the shopping mall, when the engine was turned off, the car could not be locked or re-started again. Jin Song had to take a taxi to the mall to pass the key-fob. This is really the motivation for the model.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Text = "Number of Owners";
                    //this.Label_To.Visible = false;
                    //this.NUP_Number.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Prof. Dong JinSong";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2008, 12, 3)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.HadoopArchitecture:
                    this.Text = "Hadoops Parallel Architecture";
                    this.TextBox_Description.Text = "Hadoop, the open source implementation of MapReduce has quickly gained popularity because it abstracts away system level details from users, leaving a parallel black-box to program in. Any Hadooop cluster setup has at least four kinds of processes-namenodes, datanodes, jobtrackers and tasktrackers. \r\n\r\nSince Hadoop is a large project, the full architecture has not been model in PAT. Instead, it focuses on the relationship between the namenode and datanode. Data locality properties has also been modeled and identified. The system modeling is as below: \r\n\r\nStart up: the most natural way to bring up a cluster to ready state is to start up the namenode first followed by the jobtracker or datanodes, which are both depending on namenode), and then, the tasktracker depending on jobtracker. \r\n\r\nAfter the namenode ahs verified that sufficient datanodes are online, it will allow the cluster to exit safe mode.=-> computation. \r\n\r\nWork: the datanode contacts the namenode to tell it is ready to receive tasks. The namenode activates the jobtracker and it selects and assigns the task and relevant block to the datanode. The datanode processes the task and recourses.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    //this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Group";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 12, 22)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.TelecommunicationServiceSystem:
                    this.Text = "Telecommunication Service System";
                    this.TextBox_Description.Text = "The telecommunication service system models the interaction between concurrent clients (users) according to the designed communication protocol as specified by the system. Apart from the basic services, users can incrementally request new features to the system. The complex of interaction between users, and the incremental adding new features to the system may lead to unpredictable and undesirable results. Some new features may conflict with each other, or hinder the basic services. This model reflects the high-level design of the system, the interaction between users and the compatibility of new features. We also use model-checking techniques to verify if all system requirements are satisfied.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Text = "Number of Users";
                    //this.Label_To.Visible = false;
                    //this.NUP_Number.Visible = false;
                    //Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT";
                    //Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2008, 12, 3)).ToShortDateString();
                    //Label_CreatedBy.Tag = true;
                    break;
                case PATExample.LiftingTruckSystem:
                    this.Text = "Lifting Truck System";
                    this.TextBox_Description.Text = "The system consists of 3 lifts. Each lift supports one wheel of a vehicle. The system is operated by means of buttons on the lifts. Lifts are connected by a bus. The model describes the startup phase and the up/down synchronization mechanism.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    //Label_CreatedBy.Text = Label_CreatedBy.Text + " Prof. Dong JinSong";
                    //Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2008, 12, 3)).ToShortDateString();
                    //Label_CreatedBy.Tag = true;
                    break;
                case PATExample.FlashMemoryDeviceDriver:
                    this.Text = "Flash Memory Device Driver";
                    this.TextBox_Description.Text = "In this example, we verify the functional correctness of multi-sector read read operation of the Samsung OneNAND flash device driver.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Andy Koh";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 06, 16)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;
                case PATExample.DrivingPhilosopher:
                    this.Text = "Driving Philosopher";
                    this.TextBox_Description.Text = "The Driving Philosophers is a new synchronization problem in mobile ad-hoc systems. In this problem, an unbounded number of driving philosophers (processes) try to access a round-about (set of shared resources, organized along a logical ring).";
                    this.CheckBox_HasThink.Text = "Number of Resources";
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Value = 4;
                    this.NUP_Size.Maximum = 100;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Number of Philosophers";
                    this.toolTip1.SetToolTip(Label_To, "The number of philosophers in the algorithm");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 10;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    break;
                case PATExample.SSL:
                    this.Text = "Secure Sockets Layer (SSL) Protocol";
                    this.TextBox_Description.Text = "This model demonstrates how to re-uncover a flaw in the secure sockets layer protocol that allows attackers to inject text into encrypted traffic passing between two endpoints. \r\n\r\nThe vulnerability in the transport layer security protocol allows man-in-the-middle attackers to surreptitiously introduce text at the beginning of an SSL session, said Marsh Ray, a security researcher who discovered the bug. A typical SSL transaction may be broken into multiple sessions, providing the attacker ample opportunity to sneak password resets and other commands into communications believed to be cryptographically authenticated.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Sun Jun";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 07, 29)).ToShortDateString();
                    Label_CreatedBy.Tag = true;

                    break;
                //case PATExample.ParallelExample:
                //    this.Text = "Parallel Model Checking Demonstration 1";
                //    this.TextBox_Description.Text = "This example demonstrates the effectiveness of parallel model checking. Depending on the number of CPU cores, please choose the different number of threads.";
                //    this.CheckBox_HasThink.Text = "Number of Loops";
                //    this.NUP_Size.Visible = true;
                //    this.NUP_Size.Minimum = 5000;
                //    this.NUP_Size.Maximum = 100000;
                //    this.NUP_Size.Value = 10000;
                //    this.Panel_FairType.Visible = false;
                //    this.Panel_EventType.Visible = false;
                //    this.Label_To.Text = "The number of threads";
                //    this.toolTip1.SetToolTip(Label_To, "");
                //    this.NUP_Number.Minimum = 2;
                //    this.NUP_Number.Value = 3;
                //    this.NUP_Number.Maximum = 20;
                //    this.RadioButton_SL.Visible = false;
                //    this.RadioButton_WL.Visible = false;
                //    break;
                case PATExample.ParallelExample2:
                    this.Text = "Parallel Model Checking Demonstration 2";
                    this.TextBox_Description.Text = "This example demonstrates the effectiveness of parallel model checking. Depending on the number of CPU cores, please choose the different number of threads.";
                    this.CheckBox_HasThink.Text = "Number of Loops";
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 5000;
                    this.NUP_Size.Maximum = 100000;
                    this.NUP_Size.Value = 10000;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "The number of threads";
                    this.toolTip1.SetToolTip(Label_To, "");
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Maximum = 20;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    break;
                case PATExample.BuyerSeller:
                    this.Text = "Online Shopping System";
                    this.TextBox_Description.Text = "In this example, a simple choreography coordinates three roles (i.e., Buyer, Seller and Shipper) to complete an online business transaction. An orchestration model realizes the choreography using three dedicated roles. \r\n\r\nThe explanation is described in the model.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    //this.Label_To.Visible = false;
                    //this.NUP_Number.Visible = false;
                    this.RadioButton_WL.Text = "Connected";
                    this.toolTip1.SetToolTip(RadioButton_WL, "Generate the connected choreography model");
                    this.RadioButton_SL.Text = "Disconnected";
                    this.toolTip1.SetToolTip(RadioButton_SL, "Generate the dis-connected choreography model");
                    Label_To.Text = "Number of Buyers";
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Value = 1;
                    this.NUP_Number.Maximum = 1024;
                    break;
                case PATExample.RoadAssistance:
                    this.Text = "Road Assistance System";
                    this.TextBox_Description.Text = "A simple road assistance system for the drivers who need help in the highway. The original WSCDL model can be downloaded at http://www.doc.ic.ac.uk/ltsa/samples/";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    break;
                case PATExample.TravelAgent:
                    this.Text = "Travel Agent System";
                    this.TextBox_Description.Text = "A travel agent system for handling the request from client. The request is passed to the employee to process first. after that, two air tickets purchase requests are sent to airline at the same time, the lower price will be used and reply to client.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    Label_To.Text = "Number of Clients";
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Value = 1;
                    this.NUP_Number.Maximum = 64;
                    this.RadioButton_WL.Text = "Deadlock";
                    this.toolTip1.SetToolTip(RadioButton_WL, "The client stops after one request");
                    this.RadioButton_SL.Text = "Deadlockfree";
                    this.toolTip1.SetToolTip(RadioButton_SL, "The client continues the request forever");
                    break;
                case PATExample.SNZI:
                    this.Text = "SNZI: Scalable Non-Zero Indicators";
                    this.TextBox_Description.Text = "We introduce the Scalable NonZero Indicator, or SNZI (pronounced \"snazzy\"), a shared object that supports Arrive and Depart operations, as well as a Query operation, which returns a boolean value indicating whether there is a surplus of Arrive operations (i.e., whether the number of Arrive operations exceeds the number of Depart operations).\r\n\r\nEllen, Lev, Luchangco and Moir presented an implementation of SNZI, which is practical, non-blocking, linearizable, scalable implementations that are fast in the absence of contention and can be instantiated for a variety of machine architectures. We implemented their algorithm and formally approved it is linearizable.\r\n\r\nFor details, please look at paper \"F. Ellen, Y. Lev, V. Luchangco, and M. Moir, SNZI: Scalable NonZero Indicators, PODC07\".";

                    this.Panel_EventType.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    //this.RadioButton_WL.Visible = false;
                    //this.RadioButton_SL.Visible = false;
                    RadioButton_WL.Text = "Detailed Model";
                    RadioButton_SL.Text = "Compact Model";
                    //this.RadioButton_WL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    //this.RadioButton_SL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.toolTip1.SetToolTip(RadioButton_WL, "Detailed Model");
                    this.toolTip1.SetToolTip(RadioButton_SL, "Compact Model");
                    NUP_Size.Visible = true;
                    CheckBox_HasThink.Text = "Number of Tree Nodes";
                    this.Label_ThirdLabel.Visible = true;
                    this.NUP_Third.Visible = true;
                    Label_ThirdLabel.Text = "Number of Operations";
                    break;
                case PATExample.LinkedList:
                    this.Text = "Linked List";
                    this.TextBox_Description.Text = "This algorithm is based on a singly linked list with sentinel nodes Head and Tail. Each node in the list contains three fields: an integer variable key, a pointer variable next and a boolean variable marked. The list is intended to be maintained in a sorted manner using the key field. The Head node always contains the minimal possible key, and the Tail node always contains the maximal possible key. The keys in these two sentinel nodes are never modified, but are only read and used for comparison. Initially the set is empty, that is, in the linked list, the next field of Head points to Tail and the next field of Tail points to null. The marked fields of both sentinel nodes are initialized to false. This algorithm consists of three methods: add, remove and contains.\r\n\r\nTo keep the list sorted, the add method first optimistically searches over the list until it finds the position where the key should be inserted. This search traversal is performed optimistically without any locking. If a key is already in the set, then the method returns false. Otherwise, the thread tries to insert the key. However, in between the optimistic traversal and the insertion, the key may have been removed, or the predecessor which should point to the new key has been removed. In either of these two cases, the algorithm does not perform the insertion and restarts its operation from the beginning of the list. Otherwise, the key is inserted and the method returns true. The operation of the remove method is similar. It iterates over the list, and if it does not find the key it is looking for, it returns false. Otherwise, it checks whether the shared invariants are violated and if they are, it restarts. If they are not violated, it physically removes the node and sets its marked field to true. The marked field and setting it to true are important because they consistute a communication mechanism to tell other threads that this node has been removed in case they end up with it after the optimistic traversal. The last method is contains. It simply iterates over the heap without any kind of synchronization, and if it finds the key it is looking for, it returns true. Otherwise, it returns false.\r\n\r\nReference: Vechev M., Yahav E., Yorsh G. Experience with Model Checking Linearizability, SPIN 2009.";

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Number of nodes";
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 10;
                    this.NUP_Size.Minimum = 2;
                    this.NUP_Size.Maximum = 50;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Number of processes";
                    this.toolTip1.SetToolTip(Label_To, "Number of processes");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 50;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.Label_ThirdLabel.Visible = true;
                    this.Label_ThirdLabel.Text = "Number of operations";
                    this.NUP_Third.Visible = true;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Zhang Shao Jie";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 20)).ToShortDateString();
                    Label_CreatedBy.Tag = true;

                    break;

                case PATExample.ParameterizedReaderWriter:
                    this.Text = "Parameterized Readers and Writers Problem";
                    this.TextBox_Description.Text = "This example demonstrates parameterized model checking of system with inifinite number of readers and writers. The property is that a reader or writer must eventually be able to access the shared variable.";

                    this.Panel_EventType.Visible = false;
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 10000000;
                    this.RadioButton_WL.Visible = true;
                    this.RadioButton_SL.Visible = true;
                    RadioButton_WL.Text = "Infinite Processes";
                    RadioButton_SL.Text = "Finite Processes";
                    this.RadioButton_WL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.RadioButton_SL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.toolTip1.SetToolTip(RadioButton_WL, "Infinite Number of Processes");
                    this.toolTip1.SetToolTip(RadioButton_SL, "Finite Number of Processes");
                    //NUP_Size.Visible = true;
                    //CheckBox_HasThink.Text = "Number of Tree Nodes";
                    //this.Label_ThirdLabel.Visible = true;
                    //this.NUP_Third.Visible = true;
                    //Label_ThirdLabel.Text = "Number of Operations";
                    CheckBox_HasThink.Visible = false;
                    Label_To.Text = "Concurrent Readers";
                    this.Panel_FairType.Visible = false;
                    //this.RadioButton_AllFair.Text = "Use Process Counter Variable";
                    //this.toolTip1.SetToolTip(RadioButton_AllFair, "Use Process Counter Variable in the model to count the number of grouped processes.");
                    //this.RadioButton_Partial.Text = "Use Global Variable";
                    //this.toolTip1.SetToolTip(RadioButton_Partial, "Use Global Variables in the model to record the number of grouped processes");
                    break;
                case PATExample.ParameterizedMetaLock:
                    this.Text = "Mutual Exclusion of Java Meta-Lock";
                    this.TextBox_Description.Text = "Metalocking is a highly-optimized technique for ensuring mutually exclusive access by threads to object monitor queues and, therefore; plays an essential role in allowing Java to offer concurrent access to objects. Metalocking can be viewed as a two-tiered scheme. At the upper level, the metalock level, a thread waits until it can enqueue itself on an object's monitor queue in a mutually exclusive manner.";
                    this.Panel_EventType.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 10000000;
                    this.RadioButton_WL.Visible = true;
                    this.RadioButton_SL.Visible = true;
                    RadioButton_WL.Text = "Infinite Threads";
                    RadioButton_SL.Text = "Finite Threads";
                    //this.RadioButton_WL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    //this.RadioButton_SL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.toolTip1.SetToolTip(RadioButton_WL, "Infinite Number of Threads");
                    this.toolTip1.SetToolTip(RadioButton_SL, "Finite Number of Threads");
                    //NUP_Size.Visible = true;
                    //CheckBox_HasThink.Text = "Number of Tree Nodes";
                    //this.Label_ThirdLabel.Visible = true;
                    //this.NUP_Third.Visible = true;
                    //Label_ThirdLabel.Text = "Number of Operations";
                    CheckBox_HasThink.Visible = false;
                    Label_To.Visible = true;
                    Label_To.Text = "Number of Threads";
                    break;
                case PATExample.ParameterizedLeaderElection:
                    this.Text = "The Self-stabilizing Leader Election in Complete Network";
                    this.TextBox_Description.Text = "This example demonstrates parameterized model checking of system with inifinite processes. There are infinite (or arbitrary) number of network nodes. The property is that eventually always there is one and only one leader in the network. 0 mean infinite number of tree nodes.";
                    this.Panel_EventType.Visible = false;
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 10000000;
                    this.RadioButton_WL.Visible = true;
                    this.RadioButton_SL.Visible = true;
                    RadioButton_WL.Text = "Infinite Nodes";
                    RadioButton_SL.Text = "Finite Nodes";
                    this.RadioButton_WL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.RadioButton_SL.CheckedChanged -= new System.EventHandler(this.RadioButton_WL_CheckedChanged);
                    this.toolTip1.SetToolTip(RadioButton_WL, "Infinite Number of Nodes");
                    this.toolTip1.SetToolTip(RadioButton_SL, "Finite Number of Nodes");
                    //NUP_Size.Visible = true;
                    //CheckBox_HasThink.Text = "Number of Tree Nodes";
                    //this.Label_ThirdLabel.Visible = true;
                    //this.NUP_Third.Visible = true;
                    //Label_ThirdLabel.Text = "Number of Operations";
                    CheckBox_HasThink.Visible = false;
                    Label_To.Visible = true;
                    Label_To.Text = "Maximum number of leaders";
                    this.Panel_FairType.Visible = false;
                    //this.RadioButton_AllFair.Text = "Use Process Counter Variable";
                    //this.toolTip1.SetToolTip(RadioButton_AllFair, "Use Process Counter Variable in the model to count the number of grouped processes.");
                    //this.RadioButton_Partial.Text = "Use Global Variable";
                    //this.toolTip1.SetToolTip(RadioButton_Partial, "Use Global Variables in the model to record the number of grouped processes");
                    break;
                case PATExample.ParameterizedStack:
                    this.Text = "Parameterized Concurrent Stack";
                    this.TextBox_Description.Text = "This example demonstrates parameterized model checking of system with inifinite processes.  The property is that a process must eventually be able to update the stack.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    Label_To.Text = "Stack Size";
                    NUP_Size.Minimum = 0;
                    NUP_Size.Maximum = 1024;
                    NUP_Size.Value = 2;
                    NUP_Size.Visible = true;
                    CheckBox_HasThink.Visible = true;
                    CheckBox_HasThink.Text = "Number of Processes";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "0 means infinite number of processes.");
                    break;
                case PATExample.ParameterizedKValuedRegister:
                    this.Text = "Multi-valued Register Simulation with Infinite Readers";
                    this.TextBox_Description.Text = "This example describes how to simulate a K-valued single-writer multi-reader register from K binary single-writer multi-reader registers for K >2. For details, refer to book \"Hagit Attiya, Jennifer Welch. Distributed Computing: Fundamentals, Simulations, and Advanced Topics, 2nd Edition. March 2004, ISBN: 978-0-471-45324-6\"";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    Label_To.Text = "K value";
                    NUP_Size.Minimum = 0;
                    NUP_Size.Maximum = 1024;
                    NUP_Size.Value = 2;
                    NUP_Size.Visible = true;
                    CheckBox_HasThink.Visible = true;
                    CheckBox_HasThink.Text = "Number of Readers";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "Number of Readers. 0 means infinite");
                    this.toolTip1.SetToolTip(Label_To, "Register Value");
                    break;
                case PATExample.LanguageFeature:
                    this.Text = "PAT Language Feature Demonstration";
                    this.TextBox_Description.Text = "This example demonstrates some language features in PAT: multi-dimentional array, synchronous and asynchornous channels, compound data passing in channal and C# library call invocations .";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Text = "Number of Missionaries and Cannibals";
                    this.toolTip1.SetToolTip(Label_To, "Number of Missionaries and Cannibals");
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    break;
                case PATExample.CSharpLibrary:
                    this.Text = "PAT Language Feature Demonstration";
                    this.TextBox_Description.Text = "This example demonstrates how to use C# libraries in PAT models. This example uses the builtin List, Stack and Queue libraries.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Zhang Shao Jie";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2009, 09, 29)).ToShortDateString();
                    Label_CreatedBy.Tag = true;

                    break;
                case PATExample.SynchronousChannelArray1:
                    this.Text = "PAT Language Feature Demonstration";
                    this.TextBox_Description.Text = "This example demonstrates some language features in PAT: one dimension synchronous channel array";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Text = "Number of Pipes";
                    this.toolTip1.SetToolTip(Label_To, "Number of Pipes");
                    this.NUP_Number.Value = 3;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 08, 31)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.SynchronousChannelArray2:
                    this.Text = "PAT Language Feature Demonstration";
                    this.TextBox_Description.Text = "This example demonstrates some language features in PAT: two dimension synchronous channel array";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    Label_To.Text = "Raw number";
                    NUP_Size.Minimum = 2;
                    NUP_Size.Value = 3;
                    NUP_Size.Visible = true;
                    CheckBox_HasThink.Visible = true;
                    CheckBox_HasThink.Text = "Column number";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "Column number");
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 08, 31)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.FischerProtocol:
                    this.Text = "Fischer's Protocol for Mutual Exclusion";
                    this.TextBox_Description.Text = "In the protocol, we examine is amutual exclusion protocol, first proposed by Fischer in 1985. Instead of using atomic test-and-set instructions or semaphores, as is nowadays often done to assuremutual exclusion, Fischer's protocol only assumes atomic reads and writes to a shared variable (when the first mutual exclusion protocols were developed in the late 1960s all exclusion protocols were of the \"shared variable kind\", later on researchers have more concentrated on the \"semaphore kind\" of protocol). Mutual exclusion in Fischer's Protocol is guaranteed by carefully placing bounds on the execution times of the instructions, leading to a protocol which is very simple, and relies heavily on time aspects.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    Label_To.Text = "No. of Processes";
                    this.toolTip1.SetToolTip(Label_To, "No. of Processes");
                    this.NUP_Number.Value = 4;
                    this.CheckBox_BDDSpecific.Visible = true;

                    break;

                    case PATExample.TwoStates:
                    this.Text = "Two State";
                    this.TextBox_Description.Text = string.Empty;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    Label_To.Text = "No. of Processes";
                    this.toolTip1.SetToolTip(Label_To, "No. of Processes");
                    this.NUP_Number.Value = 4;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;

                case PATExample.FischerProtocolTA:
                    this.Text = "Fischer's Protocol for Mutual Exclusion";
                    this.TextBox_Description.Text = "In the protocol, we examine is amutual exclusion protocol, first proposed by Fischer in 1985. Instead of using atomic test-and-set instructions or semaphores, as is nowadays often done to assuremutual exclusion, Fischer's protocol only assumes atomic reads and writes to a shared variable (when the first mutual exclusion protocols were developed in the late 1960s all exclusion protocols were of the \"shared variable kind\", later on researchers have more concentrated on the \"semaphore kind\" of protocol). Mutual exclusion in Fischer's Protocol is guaranteed by carefully placing bounds on the execution times of the instructions, leading to a protocol which is very simple, and relies heavily on time aspects.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    Label_To.Text = "No. of Processes";
                    this.toolTip1.SetToolTip(Label_To, "No. of Processes");
                    this.NUP_Number.Value = 4;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Shi Ling";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 09, 15)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.RailwayCrossing:
                    this.Text = "Railway Crossing Example";
                    this.TextBox_Description.Text = "The railway crossing system is modelled and checked, which is complex enough to demonstrate a number of aspects of the modelling and veri¯cation of timed systems. The system consists of three components: a train, a gate and a controller. The gate should be up to allow tra±c to pass when no train approaching and lowered to obstruct traffic when a train is coming. The controller monitors the approach of a train, and instructs the gate to be lowered within the appropriate time. The train is modelled abstractly with behaviors: nearing, entering and leaving the crossing.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    break;
                case PATExample.RailwayControl:
                    this.Text = "Railway Control System";
                    this.TextBox_Description.Text = "In this example, we model a railway control system to automatically control trains passing a critical point such a bridge. The idea is to use a computer to guide trains from several tracks crossing a single bridge instead of bguilding many brideges. Obviously, a safety-property of such a system is to avoid the situation where more than one train are crossing the bridge at the same time. \r\n\r\nFor more details about this example, see \"Automatic Verification of Real-Time Communicating Systems by Constraint Solving\", by Wang Yi, Paul Pettersson and Mats Daniels. In Proceedings of the 7th International  * Conference on Formal Description Techniques, pages 223-238, North-Holland. 1994.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    Label_To.Text = "No. of Trains";
                    this.toolTip1.SetToolTip(Label_To, "No. of Trains");
                    this.NUP_Number.Value = 4;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;

                case PATExample.RailwayControlTA:
                    this.Text = "Railway Control System";
                    this.TextBox_Description.Text = "In this example, we model a railway control system to automatically control trains passing a critical point such a bridge. The idea is to use a computer to guide trains from several tracks crossing a single bridge instead of bguilding many brideges. Obviously, a safety-property of such a system is to avoid the situation where more than one train are crossing the bridge at the same time. \r\n\r\nFor more details about this example, see \"Automatic Verification of Real-Time Communicating Systems by Constraint Solving\", by Wang Yi, Paul Pettersson and Mats Daniels. In Proceedings of the 7th International  * Conference on Formal Description Techniques, pages 223-238, North-Holland. 1994.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    Label_To.Text = "No. of Trains";
                    this.toolTip1.SetToolTip(Label_To, "No. of Trains");
                    this.NUP_Number.Value = 4;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Shi Ling";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 10, 05)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;

                case PATExample.PaceMakerTimed:
                    this.Text = "Timed PaceMaker";
                    this.TextBox_Description.Text = "A pacemaker is an electronic device used to treat patients who have symptoms caused by abnormally slow heartbeats. A pacemaker is capable of keeping track of the patient's heartbeats. If the patient's heart is beating too slowly, the pacemaker will generate electrical signals similar to the heart's natural signals, causing the heart to beat faster. The purpose of the pacemaker is to maintain heartbeats so that adequate oxygen and nutrients are delivered through the blood to the organs of the body. \r\n\r\n The pacemaker has several operating modes that address different malfunctions of the natural pacemaker. The operating modes of the device are classified using a code consisting of three or four characters. For the examples in this paper, the code elements are: chamber(s) paced (O for none, A for atrium, V for ventricle, D for both), chamber(s) sensed (same codes), response to sensing (O for none), response to sensing (O for none) and a final optional R to indicate the presence of rate modulation in response to the physical activity of the patient as measured by the accelerometer. X is a wildcard used to denote any letter (i.e. O, A, V or D). Thus DOO is an operating mode in which both chambers are paced but no chambers are sensed, and XXXR denotes all modes with rate modulation. In this model, we consider all 16 operating modes of the pacemaker.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    NUP_Number.Visible = false;
                    Label_To.Visible = false;
                    //Label_To.Text = "PaceMaker Mode";
                    //this.toolTip1.SetToolTip(Label_To, "PaceMaker Mode");
                    //this.NUP_Number.Minimum = 1;
                    //this.NUP_Number.Value = 2;
                    //this.NUP_Number.Maximum = 3;
                    break;
                case PATExample.LightControlSystem:
                    this.Text = "Light Control System";
                    this.TextBox_Description.Text = "Light Control System (LCS) is an intelligent control system. It can detect the occupation of a building, then turn on or turn off the lights automatically. It is able to tune illumination (in percentage) in the building according to the outside light level. A typical system behavior is that when a user enters a room: a motion detector senses the presence of the person, the room controller reacts by receiving the current daylight level and turning on the light group with appropriate illumination setting (let satisfy represent the relationship between daylight level and required illumination). When a user leaves a room (leaving it empty): the detector senses no movement, the room controller waits for absent time units and then turns off the light group. The occupant can directly turn on/off the light by pushing the button.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    NUP_Number.Visible = false;
                    Label_To.Visible = false;
                    //Label_To.Text = "PaceMaker Mode";
                    //this.toolTip1.SetToolTip(Label_To, "PaceMaker Mode");
                    //this.NUP_Number.Minimum = 1;
                    //this.NUP_Number.Value = 2;
                    //this.NUP_Number.Maximum = 3;
                    break;
                case PATExample.ABP:
                    this.Text = "Alternating Bit Protocol";
                    this.TextBox_Description.Text = "Alternating bit protocol (ABP) means a simple data link layer network protocol that retransmits lost or corrupted messages. \r\n\r\nMessages are sent from transmitter A to receiver B. Assume that the channel from A to B is initialized and that there are no messages in transit. Each message from A to B contains a data part and a one-bit sequence number, i.e., a value that is 0 or 1. B has two acknowledge characters that it can send to A: ACK0 and ACK1. We assume that the channel may corrupt a message and that there is a way in which A and B can decide whether or not they have received a correct message. How and to which extent that is possible is the subject of coding theory. When A sends a message, it sends it continuously, with the same sequence number, until it receives an acknowledgment from B that contains the same sequence number. When that happens, A complements (flips) the sequence number and starts transmitting the next message. When B receives a message that is not corrupted and has sequence number 0, it starts sending ACK0 and keeps doing so until it receives a valid message with number 1. Then it starts sending ACK1, etc. This means that A may still receive ACK0 when it is already transmitting messages with sequence number one. (And vice-versa.) It treats such messages as negative-acknowledge characters (NAKs). The simplest behaviour is to ignore them all and continue transmitting.\r\n\r\nThe protocol may be initialized by sending bogus messages and acks with sequence number 1. The first message with sequence number 0 is a real message.\r\n\r\nIn this model, we use a process to model a descrete timer.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    NUP_Number.Visible = true;
                    Label_To.Visible = true;
                    Label_To.Text = "Channel Size";
                    this.toolTip1.SetToolTip(Label_To, "The size of the channel used for the data transmission.");
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Value = 1;
                    this.NUP_Number.Maximum = 100;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Dr Sun Jun";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2009, 09, 25)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.ABPTimed:
                    this.Text = "Timed Alternating Bit Protocol";
                    this.TextBox_Description.Text = "Alternating bit protocol (ABP) means a simple data link layer network protocol that retransmits lost or corrupted messages. \r\n\r\nMessages are sent from transmitter A to receiver B. Assume that the channel from A to B is initialized and that there are no messages in transit. Each message from A to B contains a data part and a one-bit sequence number, i.e., a value that is 0 or 1. B has two acknowledge characters that it can send to A: ACK0 and ACK1. We assume that the channel may corrupt a message and that there is a way in which A and B can decide whether or not they have received a correct message. How and to which extent that is possible is the subject of coding theory. When A sends a message, it sends it continuously, with the same sequence number, until it receives an acknowledgment from B that contains the same sequence number. When that happens, A complements (flips) the sequence number and starts transmitting the next message. When B receives a message that is not corrupted and has sequence number 0, it starts sending ACK0 and keeps doing so until it receives a valid message with number 1. Then it starts sending ACK1, etc. This means that A may still receive ACK0 when it is already transmitting messages with sequence number one. (And vice-versa.) It treats such messages as negative-acknowledge characters (NAKs). The simplest behaviour is to ignore them all and continue transmitting.\r\n\r\nThe protocol may be initialized by sending bogus messages and acks with sequence number 1. The first message with sequence number 0 is a real message.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    NUP_Number.Visible = true;
                    Label_To.Visible = true;
                    Label_To.Text = "Channel Size";
                    this.toolTip1.SetToolTip(Label_To, "The size of the channel used for the data transmission.");
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Value = 1;
                    this.NUP_Number.Maximum = 100;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Dr Sun Jun";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2009, 09, 25)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.TPCP:
                    this.Text = "Two Phase Commit Protocol";
                    this.TextBox_Description.Text = "In transaction processing, databases, and computer networking, the two-phase commit protocol (2PC) is a type of atomic commitment protocol (ACP). It is a distributed algorithm that coordinates all the processes that participate in a distributed atomic transaction on whether to commit or abort (roll back) the transaction (it is a specialized type of consensus protocol). The protocol achieves its goal even in many cases of temporary system failure (involving either process, network node, communication, etc. failures), and is thus widely utilized.[1][2][3] However, it is not resilient to all possible failure configurations, and in rare cases user (e.g., a system's administrator) intervention is needed to remedy outcome. To accommodate recovery from failure (automatic in most cases) the protocol's participants use logging of the protocol's states. Log records, which are typically slow to generate but survive failures, are used by the protocol's recovery procedures. Many protocol variants exist that primarily differ in logging strategies and recovery mechanisms. Though usually intended to be used infrequently, recovery procedures comprise a substantial portion of the protocol, due to many possible failure scenarios to be considered and supported by the protocol.";
                    this.CheckBox_HasThink.Visible = false;
                    //this.CheckBox_HasThink.Text = "K";
                    //this.NUP_Size.Visible = true;
                    //this.NUP_Size.Minimum = 2;
                    //this.NUP_Size.Value = 2;
                    //this.NUP_Size.Maximum = 10;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "The number of Pages";
                    this.toolTip1.SetToolTip(Label_To, "The number of Pages in this protocol");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 100;
                    this.RadioButton_WL.Text = "Simplified";
                    this.toolTip1.SetToolTip(RadioButton_WL, "Generate the Simplified model");
                    this.RadioButton_SL.Text = "Original";
                    this.toolTip1.SetToolTip(RadioButton_SL, "Generate the Original model");
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Dr Sun Jun";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 08, 02)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.ProbabilityExample1:
                    this.Text = "Probability Example 1";
                    this.TextBox_Description.Text = "One probabilistic model, which can be found in the book \"Principles of Model Checking\" page 855.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Song Song Zheng";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 06)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.ProbabilityExample2:
                    this.Text = "Probability Example 2";
                    this.TextBox_Description.Text = "One probabilistic model, which can be found in the book \"Principles of Model Checking\" page 852.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Song Song Zheng";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 06)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.PZ82MutualExclusion:
                    this.Text = "PZ82 Mutual Exclution Algorithm";
                    this.TextBox_Description.Text = "PZ82 mutual exclusion [PZ82]\r\n\rdxp/gxn 19/12/99";
                    this.CheckBox_HasThink.Visible = false;
                    // this.CheckBox_HasThink.Text = "Maximum Ticket Bound";
                    //this.NUP_Size.Visible = true;
                    //this.NUP_Size.Minimum = 4;
                    //this.NUP_Size.Value = 4;
                    //this.NUP_Size.Maximum = 200;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "The number of processes";
                    this.toolTip1.SetToolTip(Label_To, "The number of processes in the algorithm");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 1000;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Song Song Zheng";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 06)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.RabinMutualExclution:
                    this.Text = "Rabin Mutual Exclution Algorithm";
                    this.TextBox_Description.Text = "N-processor mutual exclusion [Rab82]\r\n\r\nto remove the need for fairness constraints for this model it is sufficent to remove the self loops from the model\r\n\r\nThe step corresponding to a process making a draw has been split into two steps to allow us to identify states where a process will draw without knowing the value randomly drawn to correctly model the protocol and prevent erroneous behaviour, the two steps are atomic (i.e. no other process can move one the first step has been made) as for example otherwise an adversary can prevent the process from actually drawing in the current round by not scheduling it after it has performed the first step.";
                    this.CheckBox_HasThink.Visible = false;
                    // this.CheckBox_HasThink.Text = "Maximum Ticket Bound";
                    //this.NUP_Size.Visible = true;
                    //this.NUP_Size.Minimum = 4;
                    //this.NUP_Size.Value = 4;
                    //this.NUP_Size.Maximum = 200;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "The number of processes";
                    this.toolTip1.SetToolTip(Label_To, "The number of processes in the algorithm");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 1000;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Song Song Zheng";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 06)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.CSMACD:
                    this.Text = "CSMA/CD Protocol";
                    this.TextBox_Description.Text = "probabilistic version of kronos model \r\n\rgxn/dxp 04/12/01";

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Backoff Limit";
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 2;
                    this.NUP_Size.Value = 2;
                    this.NUP_Size.Maximum = 1000;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "The number of processes";
                    this.toolTip1.SetToolTip(Label_To, "The number of processes in the algorithm");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 1000;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Song Song Zheng";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 06)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.CSMACD_RTS:
                    this.Text = "CSMA/CD Protocol (RTS)";
                    this.TextBox_Description.Text = "CSMA/CD protocol (Carrier Sense, Multiple-Access with Collision Detection) describes a solution to the  the problem of assigning the bus to only one of many competing stations arises in a broadcast network with a multi-access bus. \n \n Our model is based on the kronos system, but we extend the two stations to more. Compared with the example in UPPAAL.";
                    this.CheckBox_HasThink.Visible = false;
                    //this.CheckBox_HasThink.Text = "Backoff Limit";
                    //this.NUP_Size.Visible = true;
                    //this.NUP_Size.Minimum = 2;
                    //this.NUP_Size.Value = 2;
                    //this.NUP_Size.Maximum = 10;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "The number of processes";
                    this.toolTip1.SetToolTip(Label_To, "The number of processes in the algorithm");
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 4;
                    this.NUP_Number.Maximum = 1000;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Shi Ling & Liu Yan";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 15)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.CSMACD_TA:
                    this.Text = "CSMA/CD Protocol (RTS)";
                    this.TextBox_Description.Text = "CSMA/CD protocol (Carrier Sense, Multiple-Access with Collision Detection) describes a solution to the  the problem of assigning the bus to only one of many competing stations arises in a broadcast network with a multi-access bus.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "The number of processes";
                    this.toolTip1.SetToolTip(Label_To, "The number of processes in the algorithm");
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 4;
                    this.NUP_Number.Maximum = 1000;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Shi Ling & Liu Yan";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 10, 06)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.MultiLifts:
                    this.Text = "Mulitple Lift System";
                    this.TextBox_Description.Text = "A multiple lift system with several lifts, floors and users. The liveness property we want to check is whether there all the requests will be served. It turns out we need week fairness to proof this property.";
                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Number of lift";
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 2;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Maximum = 50;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Number of floors";
                    this.toolTip1.SetToolTip(Label_To, "Number of floors");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 50;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.Label_ThirdLabel.Visible = true;
                    this.NUP_Third.Visible = true;
                    break;
                case PATExample.MultiLiftsPRTS:
                    this.Text = "Mulitple Lift System";
                    this.TextBox_Description.Text = "A multiple lift system with several lifts, floors and users. The liveness property we want to check is whether there all the requests will be served. It turns out we need week fairness to proof this property.";
                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Number of lift";
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 2;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Maximum = 50;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Number of floors";
                    this.toolTip1.SetToolTip(Label_To, "Number of floors");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 50;
                    this.Label_ThirdLabel.Visible = true;
                    this.NUP_Third.Visible = true;
                    this.RadioButton_SL.Text = "Random Assignment";
                    this.toolTip1.SetToolTip(RadioButton_SL, "Randomly assign an external request to a lift.");
                    this.RadioButton_WL.Text = "Nearest Assignment";
                    this.toolTip1.SetToolTip(RadioButton_WL, "Assign an external request to the nearest lift");
                    break;
                case PATExample.MultiLiftsRTS:
                    this.Text = "Real-time Mulit-Lift System";
                    this.TextBox_Description.Text = "A multiple lift system with several lifts and floors. In this lift, real-time constrants are considered which exhibits more complicated behaviors.";
                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Number of lifts";
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 2;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Maximum = 50;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Number of floors";
                    this.toolTip1.SetToolTip(Label_To, "Number of floors");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 50;
                    this.Label_ThirdLabel.Visible = false;
                    this.NUP_Third.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 05, 02)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.FDDI:
                    this.Text = "Fiber Distributed Data Interface";
                    this.TextBox_Description.Text = "Fiber Distributed Data Interface(FDDI) is a high-performance fiber-optic token ring Local Area Network. An FDDI network is composed by N identical stations and a ring, where the stations can communicate by synchronous messages with high priority or synchronous messages with low priority.";
                    this.CheckBox_HasThink.Visible = false;
                    //this.CheckBox_HasThink.Text = "Backoff Limit";
                    //this.NUP_Size.Visible = true;
                    //this.NUP_Size.Minimum = 2;
                    //this.NUP_Size.Value = 2;
                    //this.NUP_Size.Maximum = 10;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "The number of stations";
                    this.toolTip1.SetToolTip(Label_To, "The number of stations");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Maximum = 5000;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Shi Ling & Liu Yan";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 15)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    CheckBox_BDDSpecific.Visible = true;
                    break;
                case PATExample.ConsensusProb:
                    this.Text = "Consensus with Probability";
                    this.TextBox_Description.Text = "Consensus problems arise in many distributed applications, for example, when it is necessary to agree whether to commit or abort a transaction in a distributed database. A distributed consensus protocol is an algorithm for ensuring that a collection of distributed processes, which start with some initial value (1 or 2) supplied by their environment, eventually terminate agreeing on the same value.";

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "K";
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 2;
                    this.NUP_Size.Value = 2;
                    this.NUP_Size.Maximum = 10;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "The number of coins";
                    this.toolTip1.SetToolTip(Label_To, "The number of coins in the algorithm");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 10;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Song Song Zheng";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 20)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.MontyHallProblem:
                    this.Text = "Monty Hall Problem";
                    this.TextBox_Description.Text = "The Monty Hall problem is a probability puzzle loosely based on the American television game show Let's Make a Deal. The name comes from the show's original host, Monty Hall. The problem is also called the Monty Hall paradox, as it is a veridical paradox in that the result appears absurd but is demonstrably true.\r\nThe problem was originally posed in a letter by Steve Selvin to the American Statistician in 1975. A well-known statement of the problem was published in Marilyn vos Savant's \"Ask Marilyn\" column in Parade magazine in 1990: \r\nSuppose you're on a game show, and you're given the choice of three doors: Behind one door is a car; behind the others, goats. You pick a door, say No. 1, and the host, who knows what's behind the doors, opens another door, say No. 3, which has a goat. He then says to you, \"Do you want to pick door No. 2?\" Is it to your advantage to switch your choice? (Whitaker/vos Savant 1990)";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;

                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Sun Jun";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 07, 30)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.BSS:
                    this.Text = "Basic Simple Strategy(BSS) of dispersion game";
                    this.TextBox_Description.Text = "In game theory, multi-agent learning is an important research area and has been applied in a wide range of practical domains. This example is focusing on one strategy of dispersion game: Basic Simple Strategy(BSS). In this strategy, the number of agents should be eqaul to the number of actions. \r\n \r\nNote: two sub-versions are provided. One has Step and the other doesn't. Here Step means the number of Rounds in the game. So we could use these two sub-versions to check both the long term behavior and the specific behaivor within a given round.";
                    this.CheckBox_HasThink.Visible = false;
                    // this.CheckBox_HasThink.Text = "Maximum Ticket Bound";
                    //this.NUP_Size.Visible = true;
                    //this.NUP_Size.Minimum = 4;
                    //this.NUP_Size.Value = 4;
                    //this.NUP_Size.Maximum = 200;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "The number of actions";
                    this.toolTip1.SetToolTip(Label_To, "The number of actions in the algorithm");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 1000;
                    this.RadioButton_SL.Text = "No Step";
                    this.toolTip1.SetToolTip(RadioButton_SL, "no step in the specification.");
                    this.RadioButton_WL.Text = "Has Step";
                    this.toolTip1.SetToolTip(RadioButton_WL, "has step in the specification");
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " SONG Songzheng";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 09, 08)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.ESS:
                    this.Text = "Extended Simple Strategy(ESS) of dispersion game";
                    this.TextBox_Description.Text = "In game theory, multi-agent learning is an important research area and has been applied in a wide range of practical domains. This example is focusing on one strategy of dispersion game: Extended Simple Strategy(ESS). In this strategy, the number of agents could be different from the number of actions. \r\n \r\nNote: two sub-versions are provided. One has Step and the other doesn't. Here Step means the number of Rounds in the game. So we could use these two sub-versions to check both the long term behavior and the specific behaivor within a given round.";

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Number of Actions";
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 2;
                    this.NUP_Size.Value = 2;
                    this.NUP_Size.Maximum = 10;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Number of Agents";
                    this.toolTip1.SetToolTip(Label_To, "The number of Agents in the algorithm");
                    this.NUP_Number.Value = 4;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 100;
                    this.RadioButton_SL.Text = "No Step";
                    this.toolTip1.SetToolTip(RadioButton_SL, "no step in the specification.");
                    this.RadioButton_WL.Text = "Has Step";
                    this.toolTip1.SetToolTip(RadioButton_WL, "has step in the specification");
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " SONG Songzheng";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 09, 10)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.BSS3:
                    this.Text = "BSS3";
                    this.TextBox_Description.Text = "New version of BSS";

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Number of Players";
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 2;
                    this.NUP_Size.Value = 4;
                    this.NUP_Size.Maximum = 20;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Number of Channels";
                    this.toolTip1.SetToolTip(Label_To, "The number of channels in the algorithm");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 100;
                    this.RadioButton_SL.Text = "No Step";
                    this.toolTip1.SetToolTip(RadioButton_SL, "no step in the specification.");
                    this.RadioButton_WL.Text = "Has Step";
                    this.toolTip1.SetToolTip(RadioButton_WL, "has step in the specification");
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Song Song Zheng";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 09, 20)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.BitT:
                    this.Text = "Bit Transition Problem";
                    this.TextBox_Description.Text = "Bit Transition Problem";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;

                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 02, 10)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.GamblerProblem:
                    this.Text = "Gambler's Problem";
                    this.TextBox_Description.Text = "The Gambler's Problem. A gambler has the opportunity to make bets on the outcomes of a sequence of coin flips. If the coin comes up heads, then he wins as many dollars as he has staked on that flip, but if it is tails then he loses his stake. The game ends when the gambler wins by reaching his goal of 100 dollars, or loses by running out of money. On each flip, the gambler must decide what portion of his capital to stake, in integer numbers of dollars. ";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = true;
                    this.Label_To.Text = "The intial capital";
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 99;

                    Label_CreatedBy.Text = Label_CreatedBy.Text + " SSZ";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 11, 29)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.ProbDinningPhil:
                    this.Text = "Probability Dining Philosophers";
                    this.TextBox_Description.Text = "Dining Philosophers Algorithm";
                    this.CheckBox_HasThink.Visible = false;
                    //this.CheckBox_HasThink.Text = "K";
                    //this.NUP_Size.Visible = true;
                    //this.NUP_Size.Minimum = 2;
                    //this.NUP_Size.Value = 2;
                    //this.NUP_Size.Maximum = 10;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "The number of Philosophers";
                    this.toolTip1.SetToolTip(Label_To, "The number of Philosophers in the algorithm");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 10;
                    this.RadioButton_WL.Text = "Under Fairness";
                    this.toolTip1.SetToolTip(RadioButton_WL, "Generate the under fairness model");
                    this.RadioButton_SL.Text = "No Fairness";
                    this.toolTip1.SetToolTip(RadioButton_SL, "Generate the no fairness model");
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Song Song Zheng";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 20)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.DBMTesting:
                    this.Text = "DBM Testing";
                    this.TextBox_Description.Text = "Test DBM class using PAT and contracts";
                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Clock Ceiling";
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Value = 2;
                    this.NUP_Size.Maximum = 10;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "The number of timers";
                    this.toolTip1.SetToolTip(Label_To, "The number of timers");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 10;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 02, 05)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;

                case PATExample.NESCBlink:
                    this.Text = "Blink Application";
                    this.TextBox_Description.Text = "A simple test example";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Size = new System.Drawing.Size(650, 400);
                    this.Button_OK.Location = new System.Drawing.Point(220, 330);
                    this.Button_Cancel.Location = new System.Drawing.Point(350, 330);
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 01)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;

                case PATExample.NESCRadioSenseToLeds:
                    this.Text = "Radio Sense to Leds";
                    this.TextBox_Description.Text = "RadioSenseToLeds samples a platform's default sensor at 4Hz and broadcasts this value in an AM packet. A RadioSenseToLeds node that hears a broadcast displays the bottom three bits of the value it has received. This application is a useful test to show that basic AM communication, timers, and the default sensor work.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Size = new System.Drawing.Size(650, 400);
                    this.Button_OK.Location = new System.Drawing.Point(220, 330);
                    this.Button_Cancel.Location = new System.Drawing.Point(350, 330);
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 01)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;
                case PATExample.NESCTest:
                    this.Text = "Test nesC examples";
                    this.TextBox_Description.Text = "Testing the language structures of nesC.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = true;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Size = new System.Drawing.Size(650, 400);
                    this.Button_OK.Location = new System.Drawing.Point(220, 330);
                    this.Button_Cancel.Location = new System.Drawing.Point(350, 330);
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 01)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;

                //NESCTestDissemination
                case PATExample.NESCTestDissemination:
                    this.Text = "Dissemination Protocol";
                    this.TextBox_Description.Text = "Test the dissemination protocol of TinyOS.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = true;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Size = new System.Drawing.Size(650, 400);
                    this.Button_OK.Location = new System.Drawing.Point(220, 330);
                    this.Button_Cancel.Location = new System.Drawing.Point(350, 330);
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 03, 01)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;

                //NESCTestDissemination
                case PATExample.NESCKeyChain:
                    this.Text = "Key-chain Protocol";
                    this.TextBox_Description.Text = "The key-chain protocol.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = true;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Size = new System.Drawing.Size(650, 400);
                    this.Button_OK.Location = new System.Drawing.Point(220, 330);
                    this.Button_Cancel.Location = new System.Drawing.Point(350, 330);
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 09, 18)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;

                //NESCTestDissemination
                case PATExample.NESCMutesla:
                    this.Text = "Mutesla Protocol";
                    this.TextBox_Description.Text = "Mutesla Protocol.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = true;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Size = new System.Drawing.Size(650, 400);
                    this.Button_OK.Location = new System.Drawing.Point(220, 330);
                    this.Button_Cancel.Location = new System.Drawing.Point(350, 330);
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 09, 18)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;

                case PATExample.NESCBlinkTask:
                    this.Text = "Blink Task examples";
                    this.TextBox_Description.Text = "One timer and one led";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Size = new System.Drawing.Size(650, 400);
                    this.Button_OK.Location = new System.Drawing.Point(220, 330);
                    this.Button_Cancel.Location = new System.Drawing.Point(350, 330);
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 01)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;

                case PATExample.NESCBlinkToRadio:
                    this.Text = "Blink to Radio";
                    this.TextBox_Description.Text = "Toggle leds, send and receive messages";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Size = new System.Drawing.Size(650, 400);
                    this.Button_OK.Location = new System.Drawing.Point(220, 330);
                    this.Button_Cancel.Location = new System.Drawing.Point(350, 330);
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 01)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;

                //case PATExample.NESCPowerup:
                //    this.Text = "Power Up";
                //    this.TextBox_Description.Text = "Simple Power up application";
                //    this.CheckBox_HasThink.Visible = false;
                //    this.Panel_FairType.Visible = false;
                //    this.Panel_EventType.Visible = false;
                //    this.RadioButton_WL.Visible = false;
                //    this.RadioButton_SL.Visible = false;
                //    this.Label_To.Visible = false;
                //    this.NUP_Number.Visible = false;
                //    this.GroupBox_Options.Visible = false;
                //    this.Size = new System.Drawing.Size(650, 400);
                //    this.Button_OK.Location = new System.Drawing.Point(220, 330);
                //    this.Button_Cancel.Location = new System.Drawing.Point(350, 330);
                //    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                //    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 01)).ToShortDateString();
                //    this.Label_CreatedBy.Tag = true;
                //    break;

                case PATExample.NESCRadioCountToLeds:
                    this.Text = "Radio Count to Leds";
                    this.TextBox_Description.Text = "Send and receive messages and count them";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Size = new System.Drawing.Size(650, 400);
                    this.Button_OK.Location = new System.Drawing.Point(220, 330);
                    this.Button_Cancel.Location = new System.Drawing.Point(350, 330);
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 01)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;

                case PATExample.NESCSense:
                    this.Text = "Simple Sense examples";
                    this.TextBox_Description.Text = "Sensing";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Size = new System.Drawing.Size(650, 400);
                    this.Button_OK.Location = new System.Drawing.Point(220, 330);
                    this.Button_Cancel.Location = new System.Drawing.Point(350, 330);
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 01, 01)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;

                case PATExample.NESCTrickleWtTimer:
                    this.Text = "Trickle Protocol with Timer";
                    this.TextBox_Description.Text = "An implementation of the Trickle protocol with timer used.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Number of Sensors";
                    this.toolTip1.SetToolTip(Label_To, "Number of Sensors");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 3;
                    this.Label_ThirdLabel.Visible = false;
                    this.NUP_Third.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 03, 01)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;

                case PATExample.NESCLeaderElectionWtTimer:
                    this.Text = "Leader Election with Timer";
                    this.TextBox_Description.Text = "An implementation of the leader election protocol with timer used.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Number of Sensors";
                    this.toolTip1.SetToolTip(Label_To, "Number of Sensors");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 3;
                    this.Label_ThirdLabel.Visible = false;
                    this.NUP_Third.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 03, 01)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;

                case PATExample.NESCTrickle:
                    this.Text = "Trickle";
                    this.TextBox_Description.Text = "Trickle is a protocol for propagating and maintaining information of a sensor network while reducing the traffic of the network as much as possible.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Number of Sensors";
                    this.toolTip1.SetToolTip(Label_To, "Number of Sensors");
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 6;
                    this.Label_ThirdLabel.Visible = false;
                    this.NUP_Third.Visible = false;
                    this.RadioButton_SL.Visible = true;
                    this.RadioButton_SL.Text = "Star";
                    this.toolTip1.SetToolTip(RadioButton_SL, "Star topology");
                    this.RadioButton_WL.Visible = true;
                    this.RadioButton_WL.Text = "Single tracked ring";
                    this.toolTip1.SetToolTip(RadioButton_WL, "Single tracked ring topology");
                    //this.RadioButton_Partial.Text = "Ring";
                    //this.toolTip1.SetToolTip(RadioButton_Partial, "Ring topology");
                    //this.RadioButton_LiveEvent.Visible = true;
                    //this.RadioButton_LiveEvent.Text = "Ring";
                    //this.toolTip1.SetToolTip(RadioButton_LiveEvent, "Ring topology");
                    break;

                case PATExample.NESCTrickleNew:
                    this.Text = "Trickle New Implementation";
                    this.TextBox_Description.Text = "Trickle is a protocol for propagating and maintaining information of a sensor network while reducing the traffic of the network as much as possible. This implementation is based on the RFC 6206 documentation of Trickle.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Number of Sensors";
                    this.toolTip1.SetToolTip(Label_To, "Number of Sensors");
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Maximum = 4;
                    this.Label_ThirdLabel.Visible = false;
                    this.NUP_Third.Visible = false;
                    this.RadioButton_SL.Visible = true;
                    this.RadioButton_SL.Text = "Star";
                    this.toolTip1.SetToolTip(RadioButton_SL, "Star topology");
                    this.RadioButton_WL.Visible = true;
                    this.RadioButton_WL.Text = "Ring";
                    this.toolTip1.SetToolTip(RadioButton_WL, "Ring topology");
                    //this.RadioButton_Partial.Text = "Ring";
                    //this.toolTip1.SetToolTip(RadioButton_Partial, "Ring topology");
                    //this.RadioButton_LiveEvent.Visible = true;
                    //this.RadioButton_LiveEvent.Text = "Ring";
                    //this.toolTip1.SetToolTip(RadioButton_LiveEvent, "Ring topology");
                    break;
                case PATExample.NESCTestFanInFanOut:
                    this.Text = "Fan in and fan out example.";
                    this.TextBox_Description.Text = "In this example, some modules are shared and thus fan in is applied implicitly.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = true;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Size = new System.Drawing.Size(650, 400);
                    this.Button_OK.Location = new System.Drawing.Point(220, 330);
                    this.Button_Cancel.Location = new System.Drawing.Point(350, 330);
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 10, 01)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;

                    break;

                case PATExample.NESCMultihopOscilloscope:
                    this.Text = "Multihop Oscillo-scope Application";
                    this.TextBox_Description.Text = "The application code is from the tutorial set of TinyOS. MultihopOscilloscope is a simple data-collection demo. It periodically samples the default sensor and broadcasts a message every few readings.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = true;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Size = new System.Drawing.Size(650, 400);
                    this.Button_OK.Location = new System.Drawing.Point(220, 330);
                    this.Button_Cancel.Location = new System.Drawing.Point(350, 330);
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 09, 25)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;

                case PATExample.NESCTrafficLights:
                    this.Text = "Traffic Lights System";
                    this.TextBox_Description.Text = "An implementation of a traffic light system.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = true;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Size = new System.Drawing.Size(650, 400);
                    this.Button_OK.Location = new System.Drawing.Point(220, 330);
                    this.Button_Cancel.Location = new System.Drawing.Point(350, 330);
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 09, 25)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;

                case PATExample.NESCAntiTheft:
                    this.Text = "Anti-theft System";
                    this.TextBox_Description.Text = "This is the anti-theft application from TinyOS's distribution.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = true;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Size = new System.Drawing.Size(650, 400);
                    this.Button_OK.Location = new System.Drawing.Point(220, 330);
                    this.Button_Cancel.Location = new System.Drawing.Point(350, 330);
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 09, 25)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;

                case PATExample.NESCTestNetwork:
                    this.Text = "Test Collection Protocol";
                    this.TextBox_Description.Text = "The application tests the collection protocol implemented in TinyOS.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = true;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Size = new System.Drawing.Size(650, 400);
                    this.Button_OK.Location = new System.Drawing.Point(220, 330);
                    this.Button_Cancel.Location = new System.Drawing.Point(350, 330);
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Manchun Zheng";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 09, 25)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;



                case PATExample.MDLAlarmController:
                    this.Text = "Alarm Controller";
                    this.TextBox_Description.Text = "An alarm control system used in cars is designed to fulfill two functions. One is to lock car doors when speed exceeds 20. The other is to sound an alarm when speed exceeds 10 and the seat belt is not fastened. \r\n\r\nThe Stateflow diagram (available in Section 3.9.2.1, PAT user manual), which models this alarm controller system, consists of two parallel states: state SpeedOmeter updates variable speed based on events timeTic and roadTic, and state Car specifies the dynamic behavior of the controller. A driver can toggle engine between status on and status off. When the engine turns on (in state EngineOn), the controller is initially at state Stopped. When speed is greater than 0, state Running is activated that contains two parallel substates: state Belts can sound an alarm based on the belt status and the speed value, and state Locks deals with the lock of car doors.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Chunqing CHEN";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 09, 18)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;

                case PATExample.MDLNewAlarmController:
                    this.Text = "New Alarm Controller";
                    this.TextBox_Description.Text = "To fix the problem of the alarm controller system, we adopt the solution proposed by Scaife et al., by adding conditions to guide the activation of default states. \r\n\r\nTo be specific, the default transition to state Stopped is guarded by condition \"[speed = 0]\" and another condition \"[speed > 0]\" is added to guard a new default transition to state Running. In addition, the default transition to state LocksOff is constrained by condition \"[speed <= 20]\" while condition \"[speed > 20]\" is inserted to guard a new default transition to state LocksOn.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Chunqing CHEN";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 09, 18)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;

                case PATExample.MDLShiftLogic:
                    this.Text = "Shift Logic";
                    this.TextBox_Description.Text = "As a part of a demo from the MathWorks that uses Simulink to model an automotive drivetrain, the Stateflow diagram (in Section 3.9.2.3, PAT user manual) models the transmission control logic, in particular, the gear selection in an automatic transimission. \r\n\r\nThe Stateflow diagram takes throttle and vehicle speed as inputs and outputs the desired gear number. It contains two parallel states, gear_state and selection_state. \r\n\r\ngear_state consists of four exclusive sub-states indicating the gear status respectively, and transitions between these sub-states are guarded by events UP and DOWN. \r\n\r\nselection_state determines the direct broadcasting of events UP and DOWN, according to the speed value and the thresholds values denoted by down_th and up_th. In addition, the event broadcasting is restricted by real-time constraints; for example, the transition broadcasting event DOWN (denoted by {gear.DOWN}) is constrained by a temporal constraint specified by \"after(TWAIT, tick)\" that checks if state downshifting has been active for at least TWAIT (a constant) period.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Chunqing CHEN";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 02, 14)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;

                case PATExample.MDLFuelControl:
                    this.Text = "Fault-tolerant Fuel Control System";
                    this.TextBox_Description.Text = "This Stateflow diagram (available in Section 3.9.2.4, PAT user manual) represents a fault management of a fuel control system. The diagram contains four parallel states to denote four separate sensors: a throttle sensor (by state Throttle), a speed sensor (state Speed), an oxygen sensor (state Oxygen), and a pressure sensor (state Pressure). Each parallel state contains two substates, a normal state and a failed state (the exception being the oxygen sensor, which also contains a warmup state). \r\n\r\nIf any of the sensor readings is outside a predefiend range, then a fault is recorded (communicated via direct event broadcasting) in parallel state Counter, and the corresponding subsystem enters its failed state. If a subsystem recovers, it can change back to the normal state and the number of faults decreases accordingly (via direct event broadcasting as well). \r\n\r\nThe parallel state at the bottom of the Stateflow diagram controls the fueling mode. It regulates the oxygen to fuel mixture ratio. If a failure is detected, then the oxygen to fuel ratio is increased. If multiple failures are detected, then the fuel system is disabled until there are no longer multiple failures in the system. Note that history junctions are used in state Running and state Low respectively to store the last active fueling mode.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Chunqing CHEN";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 02, 14)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;

                case PATExample.MDLStopwatch:
                    this.Text = "Stopwatch";
                    this.TextBox_Description.Text = "A Stopwatch with lap time measurement contains an inner counter that calculates the lapsed time represented by three variables denoting centi-second, second, and minute, respectively. In addition a display is used to show time value to users when needed. It is desired for a stopwatch to present correct time value to users. \r\n\r\nThe Stateflow diagram (available in Section 3.9.2.2, PAT user manual) representing the stopwatch comprises two states StopW and RunW. In state StopW, the counter stops, and all variables are reset to value 0 when button LAP is pressed in state Reset. In state RunW, the counter updates according to event TIC and the change is modeled by a flowchart. Furthermore the values of variables for display are equal to those of inner counter in state Running. Note that this diagram illustrates two modeling features of Stateflow: 1. inner transitions (for example, from state Reset to state Running), 2. deterministic execution order for multiple outgoing transitions from the same source state (for instance, outgoing transitions of state Running).";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Chunqing CHEN";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 09, 18)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;

                case PATExample.MDLSB:
                    this.Text = "SB Logic";
                    this.TextBox_Description.Text = "The Stateflow diagram (in Section 3.9.2.5, PAT user manual) is a simplified model specifying the control logic of SB";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Chunqing CHEN";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 09, 18)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;

                case PATExample.ORCMetronome:
                    this.Text = "Metronome";
                    this.TextBox_Description.Text = "A metronome is a timer that executes an expression repeatedly at regular intervals. In the example, it publishes \"tick\" once per second and \"tock\" once per second after an initial halfsecond delay. The publications alternate: \"tick tock tick tock ...\". Note that this program is not defined recursively; the recursion is entirely contained within metronome.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " UT Austin Team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 07, 29)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;

                case PATExample.ORCConcQuickSort:
                    this.Text = "Concurrent Quicksort";
                    this.TextBox_Description.Text = "The original quicksort algorithm was designed for efficient execution on a uniprocessor. Encoding it as a functional program typically ignores its efficient rearrangement of the elements of an array. Further, no known implementation highlights its concurrent aspects. The example attempts to overcome these two limitations. The program is mostly functional in its structure, though it manipulates the array elements in place. Parts of the algorithm is encoded as concurrent activities where sequentiality is unneeded. The detail description of the algorithm can be found in the paper \"Quicksort: Combining Concurrency, Recursion, and Mutable Data Structures\", which can be downloaded at http://orc.csres.utexas.edu/papers/qs.pdf.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = true;
                    this.Label_To.Text = "Size";
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 2;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " UT Austin Team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 07, 29)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;

                case PATExample.ORCReaderWriterProblem:
                    this.Text = "Readers-Writers Problem";
                    this.TextBox_Description.Text = "The readers-writers problem involves concurrent access to a mutable resource. Multiple readers can access the resource concurrently, but writers must have exclusive access. When readers and writers conflict, different solutions may resolve the conflict in favor of one or the other, or fairly. In the following solution, when a writer tries to acquire the lock, current readers are allowed to finish but new readers are postponed until after the writer finishes. Lock requests are granted in the order received, guaranteeing fairness.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = true;
                    this.Label_To.Text = "Size";
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 2;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " UT Austin Team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 07, 29)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;

                case PATExample.ORCAirlineAgent:
                    this.Text = "Airline Agent";
                    this.TextBox_Description.Text = "This example simulates a simple booking agent: it gets quotes from a list of airlines, and returns the best quote within $200 received within 15 seconds.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " UT Austin Team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 07, 29)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;

                case PATExample.ORCNRSDeadlockExample:
                    this.Text = "Simple NRS Deadlock Example";
                    this.TextBox_Description.Text = "A simple example where the external sites can lead to Non-Responsive (NRS) Deadlock.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Tian Huat Tan";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 08, 11)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.ORCNRSCycleExample:
                    this.Text = "Simple NRS Cycle Example";
                    this.TextBox_Description.Text = "A simple example where the external sites can lead to Non-Responsive (NRS) Cycle.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Tian Huat Tan";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 08, 11)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.ORCAuctionManagement:
                    this.Text = "Auction Management";
                    this.TextBox_Description.Text = "Auction management with external sites. Details of the case study can be found in the paper \"Real-time rewriting semantics\" by M. AlTurki and J. Meseguer. This example uses 1 time unit of forward trip delay and 1 time unit of return trip delay for all external sites, with the assumption of no non-responsive and halting behaviour as seen on the paper.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " M. AlTurki and J. Meseguer";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 08, 11)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.ORCAuctionManagementNRS:
                    this.Text = "Auction Management (NRS Checking)";
                    this.TextBox_Description.Text = "Auction management with external sites. Details of the case study can be found in the paper \"Real-time rewriting semantics\" by M. AlTurki and J. Meseguer. This example is modified from the original, to focus on the testing of non-responsive (NRS) behaviour of external sites.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Tian Huat Tan";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 08, 11)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;

                case PATExample.Needham_Schroeder_protocol:
                    this.Text = "Needham-Schroeder Public Key Authentication Protocol";
                    this.TextBox_Description.Text = "The Needham-Schroeder Public Key Protocol is a well known authentication protocol that dates back to 1978. It aims to establish mutual authentication between an initiator A and a responder B, after which some session involving the exchange of messages between A and B can take place. It is based on public key cryptography i.e. RSA and aims to establish mutual authentication between two parties communicating over an unsecure network connection. Messages are encrypted using the recipient's public key and only the recipient who holds the private key can decrypt the messages to learn its contents. We denote messages encrypted with some public key as {x,y}PK{Z} with x and y being the data items of the encrypted message and PK(Z) being the public key of the recipient Z. Private or secret keys are denoted as SK and are used for both decryption and digitally signing messages to ensure message integrity.\r\n\r\nLowe was the first to demonstrate how formal specification techniques can be used to verify the security properties of cryptographic protocols. In his seminal 1995 paper, Lowe announced the discovery of a previously unknown man-in-the-middle attack on the Needham-Schroeder public key authentication protocol. The Needham-Schroeder protocol forms the basis of the widely-used Kerberos protocol. Before Lowe's announcement the Needham-Schroeder protocol had been subjected to various verication exercises and real-world use and was deemed as secure for 17 years!\r\n\r\nIn this example, we demonstrate the original version of this protocol.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_To.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 07, 20)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    RadioButton_SL.Checked = true;
                    break;

                case PATExample.Andrew_Secure_RPC_protocol:
                    this.Text = "Andrew Secure RPC Protocol";
                    this.TextBox_Description.Text = "This protocol establishes the fresh shared symmetric key K'ab. The nonce N'b is sent in message 4 to be used in a future session. We assume that initially, the symmetric keys Kab is known only to A and B. The protocol must guaranty the secrecy of the new shared key t: in every session, the value of K'ab must be known only by the participants playing the roles of A and B. The protocol must guaranty the authenticity of t: in every session, on reception of message 4, A must be ensured that the key t in the message has been created by A in the same session";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_To.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 07, 20)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    RadioButton_SL.Checked = true;
                    break;

                case PATExample.Denning_Sacco_shared_key_protocol:
                    this.Text = "Denning-Sacco shared key";
                    this.TextBox_Description.Text = "";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_To.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 07, 20)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    RadioButton_SL.Checked = true;
                    break;

                case PATExample.Lowe_modified_Denning_Sacco_shared_key_protocol:
                    this.Text = "Lowe modified Denning-Sacco shared key";
                    this.TextBox_Description.Text = "Modified version of the Denning-Sacco shared key protocol to correct a freshness flaw.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_To.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 07, 20)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    RadioButton_SL.Checked = true;
                    break;

                case PATExample.Needham_Schroeder_Timed_protocol:
                    this.Text = "Needham-Schroeder Timed Protocol";
                    this.TextBox_Description.Text = "This is a dialect version of famous Needham Schroeder protocol. In this version, each line in protocol take 1 unit time to execute.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 0;
                    Label_To.Text = "The time allow is: ";
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 07, 20)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    RadioButton_SL.Checked = true;
                    break;

                case PATExample.FixedNeedham_Schroeder_protocol:
                    this.Text = "Fixed Needham-Schroeder Public Key Authentication Protocol";
                    this.TextBox_Description.Text = "The Needham-Schroeder Public Key Protocol is a well known authentication protocol that dates back to 1978. It aims to establish mutual authentication between an initiator A and a responder B, after which some session involving the exchange of messages between A and B can take place. It is based on public key cryptography i.e. RSA and aims to establish mutual authentication between two parties communicating over an unsecure network connection. Messages are encrypted using the recipient's public key and only the recipient who holds the private key can decrypt the messages to learn its contents. We denote messages encrypted with some public key as {x,y}PK{Z} with x and y being the data items of the encrypted message and PK(Z) being the public key of the recipient Z. Private or secret keys are denoted as SK and are used for both decryption and digitally signing messages to ensure message integrity.\r\n\r\nLowe was the first to demonstrate how formal specification techniques can be used to verify the security properties of cryptographic protocols. In his seminal 1995 paper, Lowe announced the discovery of a previously unknown man-in-the-middle attack on the Needham-Schroeder public key authentication protocol. The Needham-Schroeder protocol forms the basis of the widely-used Kerberos protocol. Before Lowe's announcement the Needham-Schroeder protocol had been subjected to various verication exercises and real-world use and was deemed as secure for 17 years!\r\n\r\nIn this example, we demonstrate fixed version of this protocol.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_To.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 07, 20)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    RadioButton_SL.Checked = true;
                    break;

                case PATExample.Wide_Mouthed_Frog_protocol:
                    this.Text = "Wide Mouthed Frog Protocol";
                    this.TextBox_Description.Text = "Distribution of a fresh shared key. Symmetric key cryptography with server and timestamps.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_To.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 07, 20)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    RadioButton_SL.Checked = true;
                    break;

                case PATExample.Fujioka_protocol:
                    this.Text = "Fujioka voting Protocol";
                    this.TextBox_Description.Text = "";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_To.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 07, 20)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    RadioButton_SL.Checked = true;
                    break;

                case PATExample.Okamoto_protocol:
                    this.Text = "Okamoto Voting Protocol";
                    this.TextBox_Description.Text = "";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_To.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 07, 20)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    RadioButton_SL.Checked = true;
                    break;

                case PATExample.Lee_protocol:
                    this.Text = "Lee voting Protocol";
                    this.TextBox_Description.Text = "";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.NUP_Number.Visible = false;
                    Label_To.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT team";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2010, 07, 20)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    RadioButton_SL.Checked = true;
                    break;
                case PATExample.Semaphore:
                    this.Text = "Semaphore";
                    this.TextBox_Description.Text = "";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    Label_To.Text = "Number Of Processes";
                    this.toolTip1.SetToolTip(Label_To, "Number Of Processes sharing the critical section");
                    this.NUP_Number.Value = 30;
                    break;
                case PATExample.Tacas:
                    this.Text = "Tacas";
                    this.TextBox_Description.Text = "";
                    this.CheckBox_HasThink.Visible = true;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Text = "Number of Processes";
                    this.toolTip1.SetToolTip(Label_To, "Number of Processes");
                    CheckBox_HasThink.Text = "Factor";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "Factor to multiply with constant");
                    this.NUP_Size.Value = 2;
                    this.NUP_Size.Visible = true;
                    //--------------------------------
                    this.NUP_Number.Value = 3;

                    break;
                //
                //PAR
                //
                case PATExample.ExRTSS:
                    this.Text = "ExRTSS";
                    this.TextBox_Description.Text = "ExRTSS";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Group";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 01, 08)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.JobShop:
                    this.Text = "Job Shop Example";
                    this.TextBox_Description.Text = "Job Shop Example";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Group";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 01, 08)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.ParFischerProtocol:
                    this.Text = "Parameterized Fischer Protocol";
                    this.TextBox_Description.Text = "Parameterized Fischer Protocol";
                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Delta";
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 3;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Maximum = 50;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "Epsilon";
                    this.toolTip1.SetToolTip(Label_To, "Number of floors");
                    this.NUP_Number.Value = 4;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 50;
                    this.Label_ThirdLabel.Visible = true;
                    this.NUP_Third.Visible = true;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Text = "Random Assignment";
                    this.toolTip1.SetToolTip(RadioButton_SL, "Randomly assign an external request to a lift.");
                    this.RadioButton_WL.Text = "Nearest Assignment";
                    this.toolTip1.SetToolTip(RadioButton_WL, "Assign an external request to the nearest lift");

                    break;
                case PATExample.TrainAHV93:
                    this.Text = "TrainAHV93";
                    this.TextBox_Description.Text = "TrainAHV93";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Group";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 01, 08)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;
                case PATExample.ParTrainCrossing:
                    this.Text = "Parameterized Train Crossing";
                    this.TextBox_Description.Text = "Parameterized Train Crossing";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Group";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 01, 08)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;


                //***********************
                //Start of BEEM Database
                //***********************
                #region BEEM Database
                /******by Pillar Meng******/
                case PATExample.BRP:
                    this.Text = "Bounded Retransmission Protocol";
                    this.TextBox_Description.Text = "The Bounded Retransmission Protocol is a protocol used in one of the Philips' products. It is based on the well-known alternating bit protocol. It allows only bounded number of retransmissions of each frame (piece of a file). This model does not include timing aspects. ";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " pillar";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 12, 22)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "Maximal Number of Retansmisions";
                    this.toolTip1.SetToolTip(Label_To, "Maximal number of retansmisions");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 50;


                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Maximal Number of Frames";
                    this.toolTip1.SetToolTip(this.CheckBox_HasThink, "Maximal number of frames in the file");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 5;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Maximum = 50;

                    this.Label_ThirdLabel.Visible = true;
                    this.Label_ThirdLabel.Text = "ERROR";
                    this.toolTip1.SetToolTip(this.Label_ThirdLabel, "Version with an error(0/1)");
                    this.NUP_Third.Visible = true;
                    this.NUP_Third.Minimum = 0;
                    this.NUP_Third.Maximum = 1;
                    this.NUP_Third.Value = 0;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;

                    break;
                case PATExample.BRP2:
                    this.Text = "Bounded Retransmission Protocol v2";
                    this.TextBox_Description.Text = "The Bounded Retransmission Protocol is a protocol used in one of the Philips' products. It is based on the well-known alternating bit protocol. It allows only bounded number of retransmissions of each frame (piece of a file). This model includes timing aspects (discrete time).  ";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " pillar";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 02, 16)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "Maximal Number of Retansmisions";
                    this.toolTip1.SetToolTip(Label_To, "Maximal number of retansmisions");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 10;


                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "MaxTime Through a Channel";
                    this.toolTip1.SetToolTip(this.CheckBox_HasThink, "Maximal time of a transmission through a channel");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 5;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Maximum = 10;

                    this.Label_ThirdLabel.Visible = true;
                    this.Label_ThirdLabel.Text = "Set T1 or TR";
                    this.toolTip1.SetToolTip(this.Label_ThirdLabel, "T1:Sender's time limit (default value 2*TD + 1); TR:Receiver's time limit (default value 2 * MAX * T1 + 3 * TD)");
                    this.NUP_Third.Visible = true;
                    this.NUP_Third.Minimum = 0;
                    this.NUP_Third.Maximum = 100;
                    this.NUP_Third.Value = 0;

                    this.Panel_EventType.Visible = true;
                    this.RadioButton_LiveEvent.Text = "T1";
                    this.RadioButton_LiveEvent.Checked = false;

                    this.RadioButton_FairEvent.Text = "TR";
                    this.RadioButton_FairEvent.Checked = false;

                    this.Panel_FairType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;

                    break;
                case PATExample.Collision:
                    this.Text = "Collision avoidance protocol ";
                    this.TextBox_Description.Text = "We assume that a number of stations are connected on an Ethernet-like medium. On top of this basic protocol we want to design a protocol without collisions. This is a simle solution with a dedicated master station, which in turn asks the other statios if they want to transmit data to another station. The provided model is rather simple, because it does not take the time aspects into consideration. ";

                    this.Label_CreatedBy.Text = this.Label_CreatedBy.Text + " pillar";
                    this.Label_CreatedAt.Text = this.Label_CreatedAt.Text + " " + (new DateTime(2011, 12, 22)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "Number of slave stations";
                    this.toolTip1.SetToolTip(Label_To, "Number of slave stations");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 10;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "ERROR";
                    this.toolTip1.SetToolTip(this.CheckBox_HasThink, "An (artifical) error in the model (0/1)");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 1;
                    this.NUP_Size.Value = 0;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.IProtocol:
                    this.Text = "Optimized sliding window protocol";
                    this.TextBox_Description.Text = "The i-protocol is a part of protocol stack; its purpose is to ensure ordered reliable duplex communication between sites. At its lower interface it assumes unreliable (lossy) packet-based FIFO connectivity. To its upper interface it provides reliable packet-based FIFO connectivity. A distinguished feature of the i-protocol is the rather sophisticated manner in which it attempts to minimize control-messages and retransmission overhead. ";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " pillar";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 12, 22)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "Size of a window";
                    this.toolTip1.SetToolTip(Label_To, "Size of a window");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 10;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Numbers used to distinguish packets";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "How many numbers are used to distinguish packets");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 3;
                    this.NUP_Size.Minimum = 2;
                    this.NUP_Size.Maximum = 20;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.LeaderFilters:
                    this.Text = "Leader election algorithm based on filters";
                    this.TextBox_Description.Text = "A filter is a piece of code that satisfy the following conditions: a) if m processes enter the filter, then at most m/2 processes exit; b) if some process enter the filter, then at least one of them exits. This model is leader election algorithm based on filters. ";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " pillar";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 12, 20)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "Number of the processes";
                    this.toolTip1.SetToolTip(Label_To, "the number of the processes");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 10;
                    this.NUP_Number.ValueChanged += new EventHandler(this.NUP_Number_ValueChanged2);

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Number of the filters";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "the number of the filters");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Enabled = false;
                    this.NUP_Size.Minimum = 2;
                    this.NUP_Size.Maximum = 10;
                    this.NUP_Size.Value = 3;

                    this.Label_ThirdLabel.Visible = true;
                    this.Label_ThirdLabel.Text = "ERROR";
                    this.toolTip1.SetToolTip(this.Label_ThirdLabel, "Presence of an (artifical) error (0/1/2)");
                    this.NUP_Third.Visible = true;
                    this.NUP_Third.Minimum = 0;
                    this.NUP_Third.Maximum = 2;
                    this.NUP_Third.Value = 0;
                    this.NUP_Third.ValueChanged += new EventHandler(this.NUP_Number_ValueChanged);

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.LeaderFiltersUnbounded:
                    this.Text = "Unbounded Leader election algorithm based on filters";
                    this.TextBox_Description.Text = "A filter is a piece of code that satisfy the following conditions: a) if m processes enter the filter, then at most m/2 processes exit; b) if some process enter the filter, then at least one of them exits. This model is leader election algorithm based on filters. ";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " pillar";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 12, 20)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "Number of the processes";
                    this.toolTip1.SetToolTip(Label_To, "the number of the processes");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 10;
                    this.NUP_Number.ValueChanged += new EventHandler(this.NUP_Number_ValueChanged);

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Number of the filters";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "the number of the filters");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Enabled = false;
                    this.NUP_Size.Minimum = 2;
                    this.NUP_Size.Maximum = 10;
                    this.NUP_Size.Value = 3;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.MCS:
                    this.Text = "MCS queue lock mutual exclusion algorithm ";
                    this.TextBox_Description.Text = "Situations, where two or more processes are reading and/or writing some shared data and the final result depends on who runs precisely when, are called race conditions. Code sections containing race conditions can be regarded as \"critical\", because such code can lead to inconsistent data. To avoid inconsistence in critical sections, exclusive access to shared data must be granted. This is called mutual exclusion, because if two processes compete for access then they have to exclude each other mutually. This is Mellor-Crummey and Scott list-based queue lock using fetch-and-store and compare-and-swap algorithm. ";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " pillar";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 12, 21)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "Number of the processes";
                    this.toolTip1.SetToolTip(this.Label_To, "the number of the processes");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 3;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "ERROR";
                    this.toolTip1.SetToolTip(this.CheckBox_HasThink, "Presence of an (artifical) error (0/1/2)");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 2;
                    this.NUP_Size.Value = 0;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.Peterson:
                    this.Text = "Peterson's mutual exclusion protocol for N processes";
                    this.TextBox_Description.Text = "Situations, where two or more processes are reading and/or writing some shared data and the final result depends on who runs precisely when, are called race conditions. Code sections containing race conditions can be regarded as \"critical\", because such code can lead to inconsistent data. To avoid inconsistence in critical sections, exclusive access to shared data must be granted. This is called mutual exclusion, because if two processes compete for access then they have to exclude each other mutually. See also other mutex examples. ";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " pillar";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 02, 14)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "Number of the processes";
                    this.toolTip1.SetToolTip(this.Label_To, "the number of the processes");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 3;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "ERROR";
                    this.toolTip1.SetToolTip(this.CheckBox_HasThink, "Presence of an (artifical) error (0/1/2)");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 2;
                    this.NUP_Size.Value = 0;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.Sorter:
                    this.Text = "Lego brick sorter";
                    this.TextBox_Description.Text = "The example is a model of a sorter of bricks built using a Lego Mindstorms systems. The Sorter consists of the following parts: 2 belts which are used to transport bricks, a light sensor which can detect passing bricks, an arm which can kick bricks from the belt, a button which is used to \"order\" bricks for processing. The intended behaviour of the system is the following. Bricks are placed by the user on the first belt. Bricks which are too long (length is detected with the use of light sensor) are kicked out from the belt by the arm. Short bricks are transported to the second belt. The second belt transports them either to a \"processing\" side or to a \"not-processing\" side depending on whether a brick has been ordered by pressing the button. Although the system is rather simple and artificial, it has several features typical for embedded systems. The model is discrete time. ";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " pillar";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 12, 21)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "SCENARIO No.";
                    this.toolTip1.SetToolTip(Label_To, "The model includes five scenarios (different combinations of short and long bricks which are inserted on the belt).");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 5;
                    this.NUP_Number.Value = 1;

                    this.NUP_Third.Minimum = 0;
                    this.NUP_Third.Value = 0;

                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.Resistance:
                    this.Text = "Model of a system for testing the quality of the cables ";
                    this.TextBox_Description.Text = "These three modeled systems simulates real complex system for testing the quality of the cables using in some Czech factories. One device is intended for accurate measuring of resistance on cables. The other device generates high voltage and this device is in safety cage together with long cabels (for example 10 km) containing several wires. One computer maintains all other systems - access to safety cage,safety lights, measuring of resistance, high voltage, results processing, etc. Real situation is rough-casted in model.png or model.svg file. * Algorithm simulates software for controlling all devices. * Device_state shows the states in whitch the hardware for measuring resistance is. * Measuring simulates the process of measuring resistance. The software finds how are several wires conneted in cable using low voltage and resistance measuring, but this functionality is not critical and therefore not modeled. The modeled Algorithm have to find the best range for the most accurate measuring. The Algorithm system asks the Measuring system for actual_resistance using synchronization \"m?\". Then the Algorithm have to test the state of the Device_state system (using qstate channel). When the state is \"Err7\" (the measured resistance is out of the range for sure), the Algorithm and Device_state used \"err\" synchronization. When the state is ok, the\"ok\" synchronization is used. ";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " pillar";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 12, 23)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "Number of measuring processes";
                    this.toolTip1.SetToolTip(Label_To, "the number of measuring processes");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 3;
                    this.NUP_Number.Value = 1;

                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                /******by Jack Lei******/
                case PATExample.Fischer:
                    this.Text = "Fisher's mutual exclusion algorithm ";
                    this.TextBox_Description.Text = "Situations, where two or more processes are reading and/or writing some shared data and the final result depends on who runs precisely when, are called race conditions. Code sections containing race conditions can be regarded as \"critical\", because such code can lead to inconsistent data. To avoid inconsistence in critical sections, exclusive access to shared data must be granted. This is called mutual exclusion, because if two processes compete for access then they have to exclude each other mutually. This model is a discrete time simulation of the Fischer's real time mutual exclusion protocol. " +
                                                    Environment.NewLine + "N: Number of the processes" +
                                                    Environment.NewLine + "K1: The 1st constant of the protocol" +
                                                    Environment.NewLine + "K2: The 2nd constant of the protocol";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Jack Lei";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 5)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "N");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 10;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "K1";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "K1");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 2;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 5;

                    this.Label_ThirdLabel.Visible = true;
                    this.Label_ThirdLabel.Text = "K2";
                    this.toolTip1.SetToolTip(Label_ThirdLabel, "K2");
                    this.NUP_Third.Visible = true;
                    this.NUP_Third.Value = 3;
                    this.NUP_Third.Minimum = 2;
                    this.NUP_Third.Maximum = 5;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.Lamport:
                    this.Text = "Lamport's fast mutual exclusion algorithm ";
                    this.TextBox_Description.Text = "A mutual exclusion algorithm, which is optimized for a number of read/write operations." +
                                                    Environment.NewLine + "N: Number of the processes" +
                                                    Environment.NewLine + "ERROR: Presence of an (artifical) error (0/1/2)"; ;

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Jack Lei";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 5)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "N");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 7;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "ERROR";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "ERROR");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 1;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 2;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.Cambridge:
                    this.Text = "Cambridge ring protocol ";
                    this.TextBox_Description.Text = "Protocol for communication between two sides (sender and receiver) over (loosy) medium." +
                                                    Environment.NewLine + "K: Size of buffer" +
                                                    Environment.NewLine + "LOSS: Channels can loose messages (0/1)" +
                                                    Environment.NewLine + "ERROR: 0 = correct model, 1,2,3 = different errors";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Jack Lei";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 5)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "K";
                    this.toolTip1.SetToolTip(Label_To, "K");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 0;
                    this.NUP_Number.Maximum = 25;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "LOSS";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "LOSS");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 1;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 1;

                    this.Label_ThirdLabel.Visible = true;
                    this.Label_ThirdLabel.Text = "ERROR";
                    this.toolTip1.SetToolTip(Label_ThirdLabel, "ERROR");
                    this.NUP_Third.Visible = true;
                    this.NUP_Third.Value = 1;
                    this.NUP_Third.Minimum = 0;
                    this.NUP_Third.Maximum = 3;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Telephony:
                    this.Text = "Telecom service ";
                    this.TextBox_Description.Text = "Model of a telecommunication service with some features (call forward when busy, ring back when free)." +
                                                    Environment.NewLine + "N: Number of users" +
                                                    Environment.NewLine + "FORWARD: Enable forward when busy feature (0/1)" +
                                                    Environment.NewLine + "BACK: Enable ring back when free feature (0/1)";
                    ;

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Jack Lei";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 5)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "N");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 0;
                    this.NUP_Number.Maximum = 6;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "FORWARD";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "FORWARD");
                    this.NUP_Size.Visible = true;
                    //this.NUP_Size.Value = 1;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 1;

                    this.Label_ThirdLabel.Visible = true;
                    this.Label_ThirdLabel.Text = "BACK";
                    this.toolTip1.SetToolTip(Label_ThirdLabel, "BACK");
                    this.NUP_Third.Visible = true;
                    //this.NUP_Third.Value = 1;
                    this.NUP_Third.Minimum = 0;
                    this.NUP_Third.Maximum = 1;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.TelephonyE:
                    this.Text = "Telecom service with ERROR) ";
                    this.TextBox_Description.Text = "Model of a telecommunication service with some features (call forward when busy, ring back when free)." +
                                                    Environment.NewLine + "N: Number of users" +
                                                    Environment.NewLine + "FORWARD: Enable forward when busy feature (0/1)" +
                                                    Environment.NewLine + "BACK: Enable ring back when free feature (0/1)";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Jack Lei";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 5)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "N");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 0;
                    this.NUP_Number.Maximum = 6;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "FORWARD";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "FORWARD");
                    this.NUP_Size.Visible = true;
                    //this.NUP_Size.Value = 1;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 1;

                    this.Label_ThirdLabel.Visible = true;
                    this.Label_ThirdLabel.Text = "BACK";
                    this.toolTip1.SetToolTip(Label_ThirdLabel, "BACK");
                    this.NUP_Third.Visible = true;
                    //this.NUP_Third.Value = 1;
                    this.NUP_Third.Minimum = 0;
                    this.NUP_Third.Maximum = 1;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Traingate:
                    this.Text = "Simple controller of a train gate ";
                    this.TextBox_Description.Text = "The example is converted from an UPPAAL demo. The clock x were modeled by new process Clock and byte x is from 0 to 25." +
                                                    Environment.NewLine + "N: The number of trains + 1" +
                                                    Environment.NewLine + "ERROR: An artificial error in the model (wrong bound)";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Jack Lei";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 6)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "N");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 10;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "ERROR";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "ERROR");
                    this.NUP_Size.Visible = true;
                    //this.NUP_Size.Value = 1;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 1;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Exit:
                    this.Text = "Model of a city team game ";
                    this.TextBox_Description.Text = "\"EXIT\" is a game for teams of 3-5 people. The game takes place in a city of Brno a lasts for 5 hours. During the game teams have to solve different tasks (e.g., ciphers) at different places. The game is highly parallel and distributed and there are quite complex prerequisities among different tasks. The goal of the game is to get into a \"modul\" before certain time limit. This is a simplified model of the game.";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Jack Lei";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 6)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N: Number of persons in a team";
                    this.toolTip1.SetToolTip(Label_To, "number of persons in a team");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 5;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "MAX: Time limit";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "time limit");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 2;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 24;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Gear:
                    this.Text = "Gear Controller ";
                    this.TextBox_Description.Text = "The gear controller is a component in the real-time embedded system that operates in a modern vehicle. The gear-requests from the driver are delivered over a communication network to the gear controller. The controller implements the actual gear change by actuating the lower level components of the system, such as the clutch, the engine and the gear-box. ";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Jack Lei ";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 6)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "MAX: Maximal gear";
                    this.toolTip1.SetToolTip(Label_To, "maximal gear");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 5;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 40;

                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Protocols0:
                    this.Text = "Simple communication protocols ";
                    this.TextBox_Description.Text = "Simple model of some basic protocol for communication over loosy channel (some simple faulty ones). " +
                                                    Environment.NewLine + "B: If the parameter is defined then the medium looses at most B messages in row (otherwise it can loose all messages).";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Jack Lei ";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 6)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "B";
                    this.toolTip1.SetToolTip(Label_To, "B");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 0;
                    this.NUP_Number.Maximum = 50;

                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Protocols1:
                    this.Text = "Simple communication protocols ";
                    this.TextBox_Description.Text = "Simple model of some basic protocol for communication over loosy channel (alternating bit protocol). ";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Jack Lei ";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 6)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Protocols2:
                    this.Text = "Simple communication protocols ";
                    this.TextBox_Description.Text = "Simple model of some basic protocol for communication over loosy channel (simple version of bounded retransmission protocol)." +
                                                     Environment.NewLine + "B: If the parameter is defined then the medium looses at most B messages in row (otherwise it can loose all messages)." +
                                                     Environment.NewLine + "MAX: Maximal number of retransmissions for BRP";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Jack Lei";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 6)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "B";
                    this.toolTip1.SetToolTip(Label_To, "B");
                    this.NUP_Number.Visible = true;
                    //this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 0;
                    this.NUP_Number.Maximum = 50;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "MAX";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "Max");
                    this.NUP_Size.Visible = true;
                    //this.NUP_Size.Value = 2;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 50;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                //*****************************by Leo Ji****************************



                case PATExample.Adding:
                    this.Text = "Adding ";
                    this.TextBox_Description.Text = "Let us consider two process P, Q running in parallel.P = loop { x=c; x=x+c; c=x;} and Q = loop { y=c; y=y+c; c=y;}. Initial value of c is 1. The claim is that c can possibly contain any natural value.With model checker we cannot prove this, but for any value, we can try to find it." +
                                                     Environment.NewLine + "VAL			:	The value of c that we want to reach." +
                                                     Environment.NewLine + "MAX			:	Bound on value of variables.";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Leo Ji";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 12)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "MAX";
                    this.toolTip1.SetToolTip(Label_To, "MAX");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 20;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 600;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "VAL";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "VAL");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 17;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Maximum = 1000;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Bridge:
                    this.Text = "Bridge ";
                    this.TextBox_Description.Text = "Four men have to cross a bridge at night. The bridge is old and dilapidated and can hold at most two people at a time. There are no railings, and the men have only one flashlight. Any party who crosses, either one or two men, must carry the flashlight with them. The flashlight must be walked back and forth; it cannot be thrown, etc. Each man walks at a different speed. One takes 5 minute to cross, another 10 minutes, another 20, and the last 25 minutes. If two men cross together, they must walk at the slower man's pace. Can they get to the other side in 60 minutes?(The model is generalized to larger number of men.)" +
                                                     Environment.NewLine + "N			:	Number of men." +
                                                     Environment.NewLine + "MAX			:	The maximum time for crossing.";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Leo Ji";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 12)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "N");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 4;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 8;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "MAX";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "MAX");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 60;
                    this.NUP_Size.Minimum = 10;
                    this.NUP_Size.Maximum = 300;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Frogs:
                    this.Text = "Frogs and Toads";
                    this.TextBox_Description.Text = "The Toads And Frogs Puzzle is also known under the names of Hares and Tortoise and Sheep and Goats, Traffic Jam, or Black and White stones. This is 2D variant of the puzzle. It takes place on NxM board. Toads move righward and downward; toads move leftward and upward. Every move is either a Slide to the nearby square or a Jump over one position, which is allowed only if the latter is occupied by a fellow of a different kind. In any case, no two animals are allowed in the same square. The goal is to switch positions of toads and frogs.)" +
                                                     Environment.NewLine + "N		:	Number of columns." +
                                                     Environment.NewLine + "M		:	Number of rows.";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Leo Ji";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 12)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "N");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 0;
                    this.NUP_Number.Maximum = 31;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "M";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "M");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 17;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Maximum = 31;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.Hanoi:
                    this.Text = "Hanoi";
                    this.TextBox_Description.Text = "The Tower of Hanoi (sometimes referred to as the Tower of Brahma or the End of the World Puzzle) was invented by the French mathematician, Edouard Lucas, in 1883.He was inspired by a legend that tells of a Hindu temple where the pyramid puzzle might have been used for the mental discipline of young priests.Legend says that at the beginning of time the priests in the temple were given a stack of 64 gold disks, each one a little smaller than the one beneath it.Their assignment was to transfer the 64 disks from one of the three poles to another, with one important proviso that a large disk could never be placed on top of a smaller one. The priests worked very efficiently, day and night. When they finished their work, the myth said, the temple would crumble into dust and the world would vanish." +
                                                     Environment.NewLine + "N		:	Number of discs.";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Leo Ji";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 12)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "N");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 8;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Maximum = 20;

                    this.CheckBox_HasThink.Visible = false;
                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.Loyd:
                    this.Text = "Loyd";
                    this.TextBox_Description.Text = "The 15 puzzle is a sliding square puzzle introduced by Sam Lloyd in 1878. It consists of 15 squares numbered from 1 to 15 which are placed in a box leaving one position out of the 16 empty.The goal is to reposition the squares from a given arbitrary starting arrangement by sliding them one at a time into a configuration, where the squares are ordered by their numbers. For more details see: http://mathworld.wolfram.com/15Puzzle.html.Because the 'fifteen' version has too big state space, we consider smaller instances as well. The goal, expressed by the reachability property below, is to reverse the order of pieces. " +
                                                     Environment.NewLine + "COLS		: 	Number of columns." +
                                                     Environment.NewLine + "ROWS		:	Number of rows.";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Leo Ji";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 12)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "ROW";
                    this.toolTip1.SetToolTip(Label_To, "ROW");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 4;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "COL";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "M");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 3;
                    this.NUP_Size.Minimum = 2;
                    this.NUP_Size.Maximum = 4;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.Peg_solitaire:
                    this.Text = "Peg_solitaire ";
                    this.TextBox_Description.Text = "Peg solitaire is an old board game for one player. The basic rules are the following: A game board with 33 holes in cross form is given. 32 pegs are in. The centre hole is empty. You have to remove the pegs one after the other by jumping horizontally or vertically over one.In the end one peg should be left. We can of course consider different variants (different boards, allow crossway jumps). " +
                                                     Environment.NewLine + "VERSION		:	The version of this game(1=square board N*N, 2=cross board, 3=cross board with pyramid pattern)" +
                                                     Environment.NewLine + "N			:	Size of the board." +
                                                     Environment.NewLine + "CROSSWAYS   :   Allow crossway jumps(0/1).";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Leo Ji";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 12)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "VERSION";
                    this.toolTip1.SetToolTip(Label_To, "VERSION");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 3;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "N";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "N");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 3;
                    this.NUP_Size.Minimum = 2;
                    this.NUP_Size.Maximum = 6;

                    this.Label_ThirdLabel.Visible = true;
                    this.Label_ThirdLabel.Text = "CROSSWAY";
                    this.toolTip1.SetToolTip(Label_ThirdLabel, "CROSSWAY");
                    this.NUP_Third.Visible = true;
                    this.NUP_Third.Value = 1;
                    this.NUP_Third.Minimum = 0;
                    this.NUP_Third.Maximum = 1;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Pouring:
                    this.Text = "Pouring ";
                    this.TextBox_Description.Text = "You are given several containers of different sizes (e.g., 8, 5, and 3 liters) and your task is to measure exactly a given content (e.g., 4 liters) in the first bottle. " + Environment.NewLine + "VAL			:	The value of c that we want to reach." +
                                                     Environment.NewLine + "VERSION			:	Version of the puzzle.";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Leo Ji";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 12)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "VERSION";
                    this.toolTip1.SetToolTip(Label_To, "VERSION");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 4;

                    this.CheckBox_HasThink.Visible = false;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.Rushhour:
                    this.Text = "RushHour ";
                    this.TextBox_Description.Text = "Rush hour is a sliding block puzzles usually played on 6x6 game plan. The goal of the puzzle is to move cars in such a way that a distinguished red car can escape the trafic jam. " + Environment.NewLine + "VAL			:	The value of c that we want to reach." +
                                                     Environment.NewLine + "VERSION			:	Version of the puzzle.";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Leo Ji";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 12)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "VERSION";
                    this.toolTip1.SetToolTip(Label_To, "VERSION");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 4;

                    this.CheckBox_HasThink.Visible = false;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.Sokoban:
                    this.Text = "Sokoban ";
                    this.TextBox_Description.Text = "A well-known computer game. The object of Sokoban is to push all stones (or boxes) in a maze, such as the one to the right, to the designated goal areas. The player controls the man and the man can only push stones and only one at a time. " + Environment.NewLine + "VAL			:	The value of c that we want to reach." +
                                                     Environment.NewLine + "VERSION			:	Version of the puzzle.";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Leo Ji";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 12)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "VERSION";
                    this.toolTip1.SetToolTip(Label_To, "VERSION");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 4;

                    this.CheckBox_HasThink.Visible = false;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Plc:
                    this.Text = "Plc ";
                    this.TextBox_Description.Text = "Model of a PLC (programable logic controler) program for experimental chemical plant. The plant consist of seven batches, heater, coolers, pumps. The model is a discrete abstraction." +
                                                     Environment.NewLine + "MAXTIME   	Maximal time of progress of the plant.";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Leo Ji";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 16)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "MAXTIME";
                    this.toolTip1.SetToolTip(Label_To, "MAXTIME");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 100;
                    this.NUP_Number.Minimum = 50;
                    this.NUP_Number.Maximum = 800;

                    this.CheckBox_HasThink.Visible = false;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                //////////////////////////////////////////////////////////////////////////////////
                // Add By Li Li
                // Time: 2012.01.16
                //////////////////////////////////////////////////////////////////////////////////
                case PATExample.Lann:
                    this.Text = "Lann";
                    this.TextBox_Description.Text = "N nodes are connected by a token ring. The token is used to guarantee mutual exclusion access to shared resource. The communications link are unreliable, i.e., token can get lost. The leader election algorithm is used for sending of a new token after the timeout. "
                        + Environment.NewLine + "N   	        Number of nodes"
                        + Environment.NewLine + "CR   	        The algorithm implements Chang and Roberts's optimalization (0/1)"
                        + Environment.NewLine + "PRECEDENCE   	The algorithm uses the precedence rule (0/1)";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Li Li";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 16)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "Number of nodes");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Value = 3;

                    this.CheckBox_HasThink.Text = "PRECEDENCE";
                    this.toolTip1.SetToolTip(Label_To, "The algorithm uses the precedence rule (0/1)");

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;

                    this.RadioButton_SL.Text = "With CR";
                    this.toolTip1.SetToolTip(RadioButton_SL, "The algorithm implements Chang and Roberts's optimalization");
                    this.RadioButton_WL.Text = "Without CR";
                    this.toolTip1.SetToolTip(RadioButton_WL, "No Chang and Roberts's optimalization");

                    break;

                case PATExample.Szymanski:
                    this.Text = "Szymanski";
                    this.TextBox_Description.Text = "Situations, where two or more processes are reading and/or writing some shared data and the final result depends on who runs precisely when, are called race conditions. Code sections containing race conditions can be regarded as \"critical\", because such code can lead to inconsistent data. To avoid inconsistence in critical sections, exclusive access to shared data must be granted. This is called mutual exclusion, because if two processes compete for access then they have to exclude each other mutually. This is szymanski's three-bit linear wait algorithm for mutual exclusion. See also other mutex examples."
                        + Environment.NewLine + "N   	Number of processes"
                        + Environment.NewLine + "ERROR   	Presence of an (artifical) error (0/1)";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Li Li";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 17)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "Number of processes");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Value = 3;

                    this.CheckBox_HasThink.Text = "ERROR";
                    this.toolTip1.SetToolTip(Label_To, "Presence of an (artifical) error (0/1)");

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Extinction:
                    this.Text = "Extinction";
                    this.TextBox_Description.Text = "Leader election algorithm for arbitrary networks based on echo wave algorithm and extinction technique. The model uses a fixed topology."
                        + Environment.NewLine + "TOPOLOGY   	The topology of the network (1 = line with 3 nodes, 2= line with 4 nodes, 3 = network of 4 nodes)"
                        + Environment.NewLine + "K   	Size of communication buffers";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Li Li";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 17)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "TOPOLOGY";
                    this.toolTip1.SetToolTip(Label_To, "The topology of the network");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 3;
                    this.NUP_Number.Value = 1;

                    this.CheckBox_HasThink.Text = "K";
                    this.toolTip1.SetToolTip(Label_To, "Size of communication buffers");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Maximum = 10;
                    this.NUP_Size.Value = 2;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;

                    break;

                case PATExample.Firewire_tree:
                    this.Text = "Firewire_tree";
                    this.TextBox_Description.Text = "The tree identify process of IEEE 1394 is a leader election protocol which takes place after a bus reset in the network (i.e. when a node is added to, or removed from, the network). Immediately after a bus reset all nodes in the network have equal status, and know only to which nodes they are directly connected. A leader (root) needs to be chosen to act as the manager of the bus for subsequent phases of the 1394. The protocol is designed for use on connected networks, will correctly elect a leader if the network is acyclic, and will report an error if a cycle is detected."
                        + Environment.NewLine + "N   	Number of nodes"
                        + Environment.NewLine + "T   	Topology: 0 = line with N nodes, 1 = fixed acyclic topology with 6 nodes, 2 = fixed cyclic topology with 6 nodes";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Li Li";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 17)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "Number of nodes");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 4;
                    this.NUP_Number.Maximum = 10;
                    this.NUP_Number.Value = 4;

                    this.CheckBox_HasThink.Text = "T";
                    this.toolTip1.SetToolTip(Label_To, "Topology");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 2;
                    this.NUP_Size.Value = 0;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;

                    break;

                case PATExample.Leader_election:
                    this.Text = "Leader_election";
                    this.TextBox_Description.Text = "The algorithm operates on a ring of N processes. Each process is assigned a unique number. The puspose of this algorithm is to find the largest number assigned to a process."
                        + Environment.NewLine + "N   	Number of nodes"
                        + Environment.NewLine + "ERROR   	Presence of an (artificial) error (0/1/2)";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Li Li";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 18)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "Number of nodes");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 4;
                    this.NUP_Number.Maximum = 10;
                    this.NUP_Number.Value = 5;

                    this.CheckBox_HasThink.Text = "ERROR";
                    this.toolTip1.SetToolTip(Label_To, "Presence of an (artificial) error (1/2)");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 2;
                    this.NUP_Size.Value = 0;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;

                    break;

                case PATExample.Msmie:
                    this.Text = "Msmie";
                    this.TextBox_Description.Text = "Multiprocessor Shared-Memory Information Exchange (MSMIE) is a protocol for communication between processors in a real-time control system. The processors are classified as either masters, which perform application-related tasks, or slaves, which provide dedicated functions. This protocol is an extension of readers (masters)/writers (slaves) problem."
                        + Environment.NewLine + "S   	Number of slaves"
                        + Environment.NewLine + "M   	Number of masters"
                        + Environment.NewLine + "N   	Size of buffer";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Li Li";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 19)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "S";
                    this.toolTip1.SetToolTip(Label_To, "Number of slaves");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 10;
                    this.NUP_Number.Value = 2;

                    this.CheckBox_HasThink.Text = "M";
                    this.toolTip1.SetToolTip(Label_To, "Number of masters");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 2;
                    this.NUP_Size.Maximum = 10;
                    this.NUP_Size.Value = 3;

                    this.Label_ThirdLabel.Visible = true;
                    this.Label_ThirdLabel.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "Size of buffer");
                    this.NUP_Third.Visible = true;
                    this.NUP_Third.Minimum = 2;
                    this.NUP_Third.Maximum = 10;
                    this.NUP_Third.Value = 3;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;

                    break;

                case PATExample.Public_subscribe:
                    this.Text = "public_subscribe";
                    this.TextBox_Description.Text = "Abstract specification (model) of the groupware protocol underlying thinkteam augmented with a publish/subscribe notification service."
                        + Environment.NewLine + "numUsers   	Number of users"
                        + Environment.NewLine + "numFiles   	Number of files";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Li Li";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 20)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "numUsers";
                    this.toolTip1.SetToolTip(Label_To, "Number of users");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 4;
                    this.NUP_Number.Value = 1;

                    this.CheckBox_HasThink.Text = "numFiles";
                    this.toolTip1.SetToolTip(Label_To, "Number of files");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Maximum = 4;
                    this.NUP_Size.Value = 3;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;

                    break;

                case PATExample.Synapse:
                    this.Text = "Synapse";
                    this.TextBox_Description.Text = "Synapse cache coherence protocol: several caches are connected by a bus, the goal of the protocol is to keep the content of the caches coherent."
                        + Environment.NewLine + "Lines   	Number of lines in a cache"
                        + Environment.NewLine + "ERROR   	Have error in it"
                        + Environment.NewLine + "N   	Number of applications and caches";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Li Li";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 25)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "Lines";
                    this.toolTip1.SetToolTip(Label_To, "Number of lines in a cache");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 5;
                    this.NUP_Number.Value = 2;

                    this.CheckBox_HasThink.Text = "ERROR";
                    this.toolTip1.SetToolTip(Label_To, "Have error in it");
                    this.NUP_Size.Visible = false;

                    this.Label_ThirdLabel.Visible = true;
                    this.Label_ThirdLabel.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "Number of applications and caches");
                    this.NUP_Third.Visible = true;
                    this.NUP_Third.Minimum = 2;
                    this.NUP_Third.Maximum = 4;
                    this.NUP_Third.Value = 2;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;

                    break;
                //*****************************by Chen Manman****************************
                case PATExample.Elevator_planning:
                    this.Text = "Elevator_planning";
                    this.TextBox_Description.Text = "Example from AIPS: the goal is to serve pasanger, there are several restricting constraints (capacity of the elevator, conflicts between pasangers, etc.)" +
                                                     Environment.NewLine + "VERSION			:	Version of the problem.";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 15)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "VERSION";
                    this.toolTip1.SetToolTip(Label_To, "VERSION");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 4;

                    this.CheckBox_HasThink.Visible = false;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.BPELTravelBookingService:
                    this.Text = "Travel Booking Service";
                    this.TextBox_Description.Text = "Travel Booking Service";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Tian Huat Tan";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 8, 20)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;
                case PATExample.BPELComputerPurchasingService:
                    this.Text = "Computer Purchasing Service";
                    this.TextBox_Description.Text = "Computer Purchasing Service";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Tian Huat Tan";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 8, 20)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;
                case PATExample.BPELStockMarketIndicesService:
                    this.Text = "Stock Market Indices Service";
                    this.TextBox_Description.Text = "Stock Market Indices Service";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Tian Huat Tan";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 8, 20)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;
                case PATExample.BPELPick_OnMessage:
                    this.Text = "Pick_OnMessage";
                    this.TextBox_Description.Text = "Pick_OnMessage";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Tian Huat Tan";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 6, 17)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;
                case PATExample.BPELWhile:
                    this.Text = "While";
                    this.TextBox_Description.Text = "While";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Tian Huat Tan";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 6, 17)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;
                case PATExample.BPELIfElse:
                    this.Text = "IfElse";
                    this.TextBox_Description.Text = "IfElse";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Tian Huat Tan";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 6, 16)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;
                case PATExample.BPELAssignment:
                    this.Text = "Assignment";
                    this.TextBox_Description.Text = "Assignment";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Tian Huat Tan";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 6, 16)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;
                case PATExample.BPELSynchronousCommunication:
                    this.Text = "Synchronous Communication";
                    this.TextBox_Description.Text = "Synchronous Communication";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Tian Huat Tan";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 6, 16)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;
                case PATExample.BPELASynchronousCommunication:
                    this.Text = "ASynchronous Communication";
                    this.TextBox_Description.Text = "ASynchronous Communication";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Tian Huat Tan";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 6, 16)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    break;
                case PATExample.LLTSReadersWritersProblem:
                    this.Text = "Readers-Writers Problem";
                    this.TextBox_Description.Text = "In computer science, the readers-writers problems are examples of a common computing problem in concurrency. The problem deals with situations in which many threads must access the same shared memory at one time, some reading and some writing, with the natural constraint that no process may access the share for reading or writing while another process is in the act of writing to it. In particular, it is allowed for two readers to access the share at the same time. In this model, a controller is used to guarantee the correct coordination among multiple readers/writers.";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 15)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "Readers";
                    this.toolTip1.SetToolTip(Label_To, "Readers");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 20;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Writers";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "Writers");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 1;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Maximum = 20;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.LLTSLamport:
                    this.Text = "Lamport's fast mutual exclusion algorithm";
                    this.TextBox_Description.Text = "A mutual exclusion algorithm, which is optimized for a number of read/write operations." +
                                                   Environment.NewLine + "N: Number of the processes" +
                                                   Environment.NewLine + "ERROR: Presence of an (artifical) error (0/1/2)"; ;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 5, 13)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "N");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Maximum = 20;
                    this.NUP_Number.Value = 3;


                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "ERROR";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "ERROR");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 2;
                    this.NUP_Size.Value = 0;


                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.LLTSMCS:
                    this.Text = "MCS queue lock mutual exclusion algorithm";
                    this.TextBox_Description.Text = "Situations, where two or more processes are reading and/or writing some shared data and the final result depends on who runs precisely when, are called race conditions. Code sections containing race conditions can be regarded as \"critical\", because such code can lead to inconsistent data. To avoid inconsistence in critical sections, exclusive access to shared data must be granted. This is called mutual exclusion, because if two processes compete for access then they have to exclude each other mutually. This is Mellor-Crummey and Scott list-based queue lock using fetch-and-store and compare-and-swap algorithm." +
                                                   Environment.NewLine + "N: Number of the processes" +
                                                   Environment.NewLine + "ERROR: Presence of an (artifical) error (0/1/2)"; ;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 5, 13)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "N");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Maximum = 20;
                    this.NUP_Number.Value = 4;


                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "ERROR";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "ERROR");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 2;
                    this.NUP_Size.Value = 0;


                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.LLTSAnderson:
                    this.Text = "Andersons queue lock mutual exclusion algorithm";
                    this.TextBox_Description.Text = "Situations, where two or more processes are reading and/or writing some shared data and the final result depends on who runs precisely when, are called race conditions. Code sections containing race conditions can be regarded as \"critical\", because such code can lead to inconsistent data. To avoid inconsistence in critical sections, exclusive access to shared data must be granted. This is called mutual exclusion, because if two processes compete for access then they have to exclude each other mutually. See also other mutex examples." +
                                                   Environment.NewLine + "N: Number of the processes" +
                                                   Environment.NewLine + "ERROR: Presence of an (artifical) error (0/1)"; ;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 5, 13)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "N");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 20;
                    this.NUP_Number.Value = 3;


                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "ERROR";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "ERROR");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 1;
                    this.NUP_Size.Value = 0;


                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.Krebs:
                    this.Text = "Krebs";
                    this.TextBox_Description.Text = "The Krebs cycle is a series of chemical reactions of central importance in all living cells that utilize oxygen as part of cellular respiration. In these aerobic organisms, the citric acid cycle is a metabolic pathway that forms part of the break down of carbohydrates, fats and proteins into carbon dioxide and water in order to generate energy. It is the second of three metabolic pathways that are involved in fuel molecule catabolism and ATP production. This model is a scheduling problem inspired by the Krebs cycle." +
                                                     Environment.NewLine + "GLUKOSA			:		Number of glukosa molecules at the beginning." +
                                                     Environment.NewLine + "KREBS           :       Number of Krebs cycles(i.e., number of oxalacetrat molecules) at the beginning" +
                                                     Environment.NewLine + "X               :       Number of units of energy";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 15)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "GLUKOSA";
                    this.toolTip1.SetToolTip(Label_To, "GLUKOSA");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 20;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "KREBS";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "KREBS");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 1;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 4;

                    this.Label_ThirdLabel.Visible = true;
                    this.Label_ThirdLabel.Text = "X";
                    this.toolTip1.SetToolTip(Label_ThirdLabel, "X");
                    this.NUP_Third.Visible = true;
                    this.NUP_Third.Value = 5;
                    this.NUP_Third.Minimum = 0;
                    this.NUP_Third.Maximum = 100;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.LLTSKrebs:
                    this.Text = "Krebs";
                    this.TextBox_Description.Text = "The Krebs cycle is a series of chemical reactions of central importance in all living cells that utilize oxygen as part of cellular respiration. In these aerobic organisms, the citric acid cycle is a metabolic pathway that forms part of the break down of carbohydrates, fats and proteins into carbon dioxide and water in order to generate energy. It is the second of three metabolic pathways that are involved in fuel molecule catabolism and ATP production. This model is a scheduling problem inspired by the Krebs cycle." +
                                                     Environment.NewLine + "GLUKOSA			:		Number of glukosa molecules at the beginning." +
                                                     Environment.NewLine + "KREBS           :       Number of Krebs cycles(i.e., number of oxalacetrat molecules) at the beginning" +
                                                     Environment.NewLine + "X               :       Number of units of energy";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 15)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "GLUKOSA";
                    this.toolTip1.SetToolTip(Label_To, "GLUKOSA");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 20;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "KREBS";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "KREBS");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 1;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 4;

                    this.Label_ThirdLabel.Visible = true;
                    this.Label_ThirdLabel.Text = "X";
                    this.toolTip1.SetToolTip(Label_ThirdLabel, "X");
                    this.NUP_Third.Visible = true;
                    this.NUP_Third.Value = 5;
                    this.NUP_Third.Minimum = 0;
                    this.NUP_Third.Maximum = 100;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;


                case PATExample.Schedule_world:
                    this.Text = "Schedule_world";
                    this.TextBox_Description.Text = "Simplified model of 'schedule world' example from AIPS 2000 contest. The model contains lot of rather independent and sometimes irelevant things, thus the state explosion is really big. " +
                                                     Environment.NewLine + "VERSION			:	Version of the problem.";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 15)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "VERSION";
                    this.toolTip1.SetToolTip(Label_To, "VERSION");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 2;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 45;

                    this.CheckBox_HasThink.Visible = false;

                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Bopdp:
                    this.Text = "Bopdp";
                    this.TextBox_Description.Text = "This protocol controls the transitions between stand-by mode and power on mode in the company's new series of products, where power consumption minimization is an important feature. (The model is manual translation of the Uppaal model; currently without time)" +
                                                     Environment.NewLine + "MAX_AP_INTS			:   Maximal number of aplication interrupts (255=unbounded)" +
                                                     Environment.NewLine + "MAX_LSL_INTS        :   Maximal number of LSL interrupts (255=unbounded)";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 15)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "MAX_AP_INTS";
                    this.toolTip1.SetToolTip(Label_To, "MAX_AP_INTS");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 7;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 255;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "MAX_LSL_INTS";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "MAX_LSL_INTS");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 7;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Maximum = 255;

                    this.Label_ThirdLabel.Visible = false;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Elevator:
                    this.Text = "Elevator";
                    this.TextBox_Description.Text = "Elevator controller,Just some variation on the popular elevator theme" +
                                                     Environment.NewLine + "Floors			:		Number of floors." +
                                                     Environment.NewLine + "Persons         :       Number of users." +
                                                     Environment.NewLine + "Strategy        :       Strategy used by the controller (0,1).";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 15)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "Floors";
                    this.toolTip1.SetToolTip(Label_To, "Floors");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 5;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 7;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "Persons";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "Persons");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 2;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Maximum = 6;

                    this.Label_ThirdLabel.Visible = true;
                    this.Label_ThirdLabel.Text = "Strategy";
                    this.toolTip1.SetToolTip(Label_ThirdLabel, "Strategy");
                    this.NUP_Third.Visible = true;
                    this.NUP_Third.Value = 1;
                    this.NUP_Third.Minimum = 0;
                    this.NUP_Third.Maximum = 2;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Lifts:
                    this.Text = "Bopdp";
                    this.TextBox_Description.Text = "The system consists of an arbitrary number of lifts. Each lift supports one wheel of a vehicle. The system is operated by means of buttons on the lifts. Lifts are connected by a bus. The model describes the startup phase and the up/down synchronization mechanism." +
                                                     Environment.NewLine + "N   	            : Number of lifts" +
                                                     Environment.NewLine + "ENV   	            : Environment (0= just three commands (init, up, down); 1= init command followed by arbitrary up/down commands, 2=arbitrary commands)";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 15)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "N");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 10;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "ENV";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "ENV");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 1;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 2;

                    this.Label_ThirdLabel.Visible = false;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Production_cell:
                    this.Text = "Bopdp";
                    this.TextBox_Description.Text = "The task of the production cell case study was to develop control software for a realistic industrial production cell, comprising several machines (e.g., a robot, a press, two conveyor belts)." +
                               Environment.NewLine + " This software had to fulfill certain safety and liveness requirements (e.g., never close the press while a robot arm is inside it). The example was taken from real world (a metal processing plant in Germany), but was at the same time of managable complexity. This model captures just the basic structure of the problem." +
                                                     Environment.NewLine + "N   	            : Number of plates" +
                                                     Environment.NewLine + "MAX   	            :  	Number of plates to process. (0=not specified)";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 1, 15)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;

                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "N");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 10;

                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "MAX";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "MAX");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Value = 1;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 5;

                    this.Label_ThirdLabel.Visible = false;

                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                //*****************************by Wang Ting****************************
                case PATExample.Elevator2:
                    this.Text = "Elevator2";
                    this.TextBox_Description.Text = "Motivated by elevator promela model from the SPIN distribution, but actually implements LEGO elevator model built in the Paradise laboratory. Naive controller chooses the next floor to be served randomly, clever controller chooses the next floor to be served to be the next requested one in the direction of the last cab movement, if there is no such floor then in direction oposite to the direction of the last cab movement.";
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.Label_To.Text = "The number of served floors";
                    this.toolTip1.SetToolTip(Label_To, "The number of served floors");
                    this.NUP_Number.Value = 4;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 100;
                    this.RadioButton_WL.Text = "Clever Controller";
                    this.toolTip1.SetToolTip(RadioButton_WL, "Clever Control Algorithm");
                    this.RadioButton_SL.Text = "Naive Controller";
                    this.toolTip1.SetToolTip(RadioButton_SL, "Naive Control Algorithm");
                    Label_CreatedBy.Text = Label_CreatedBy.Text + " Wang Ting";
                    Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 02, 01)).ToShortDateString();
                    Label_CreatedBy.Tag = true;
                    break;

                case PATExample.Lup:
                    this.Text = "Lup";
                    this.TextBox_Description.Text = "Sharing SRAM and CAM by lookup processors." +
                                                     Environment.NewLine + "N	:	Number of lookup processors.";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Wang Ting";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 2, 1)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "Number of lookup processors");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Value = 4;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 10;
                    this.CheckBox_HasThink.Visible = false;
                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Blocks:
                    this.Text = "Blocks";
                    this.TextBox_Description.Text = "Popular example from planning community. There is a set of blocks on infinite table and the goal is to put blocks into a certain configuration." +
                                                     Environment.NewLine + "Version	:	Version of the problem.";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Wang Ting";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 2, 1)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.Label_To.Text = "Version";
                    this.toolTip1.SetToolTip(Label_To, "Version of the problem");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 0;
                    this.NUP_Number.Maximum = 150;
                    this.NUP_Number.Value = 0;
                    this.CheckBox_HasThink.Visible = false;
                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Anderson:
                    this.Text = "Anderson";
                    this.TextBox_Description.Text = "Situations, where two or more processes are reading and/or writing some shared data and the final result depends on who runs precisely when, are called race conditions. Code sections containing race conditions can be regarded as \"critical\", because such code can lead to inconsistent data. To avoid inconsistence in critical sections, exclusive access to shared data must be granted. This is called mutual exclusion, because if two processes compete for access then they have to exclude each other mutually. See also other mutex examples." +
                                                     Environment.NewLine + "N   	:    Number of processes" +
                                                     Environment.NewLine + "ERROR   :  	 Presence of an (artifical) error (0/1)";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Wang Ting";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 2, 1)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "Number of processes");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 10;
                    this.NUP_Number.Value = 3;
                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "ERROR";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "ERROR");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 1;
                    this.NUP_Size.Value = 0;
                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                //*****************************by Xuan Xiao****************************
                case PATExample.At:
                    this.Text = "Alur-Taubenfeld";
                    this.TextBox_Description.Text = "Dicrete time model of Alur-Taubenfeld fast timing-based mutual exclusion algorithm.";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Xuan Xiao";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 2, 1)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "Number of processes");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 6;
                    this.NUP_Number.Value = 3;
                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "K1";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "Time needed to perform write/read operation");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 1;
                    this.NUP_Size.Maximum = 3;
                    this.NUP_Size.Value = 2;
                    this.Label_ThirdLabel.Visible = true;
                    this.Label_ThirdLabel.Text = "K2";
                    this.toolTip1.SetToolTip(Label_ThirdLabel, "Delay parameter of the algorithm (to ensure mutual exclusion K2 must be larger than 2*K1)");
                    this.NUP_Third.Visible = true;
                    this.NUP_Third.Minimum = 2;
                    this.NUP_Third.Maximum = 6;
                    this.NUP_Third.Value = 5;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                case PATExample.Lamport_Nonatomic:
                    this.Text = "Lamport Nonatomic";
                    this.TextBox_Description.Text = "A mutual exclusion algorithm. In this case, read and write operations need not be atomic.";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Xuan Xiao";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 2, 1)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.Label_To.Text = "N";
                    this.toolTip1.SetToolTip(Label_To, "Number of processes");
                    this.NUP_Number.Visible = true;
                    this.NUP_Number.Minimum = 2;
                    this.NUP_Number.Maximum = 5;
                    this.NUP_Number.Value = 3;
                    this.CheckBox_HasThink.Visible = true;
                    this.CheckBox_HasThink.Text = "ERROR";
                    this.toolTip1.SetToolTip(CheckBox_HasThink, "Presence of an (artifical) error (0/1/2)");
                    this.NUP_Size.Visible = true;
                    this.NUP_Size.Minimum = 0;
                    this.NUP_Size.Maximum = 2;
                    this.NUP_Size.Value = 0;
                    this.Label_ThirdLabel.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;

                #endregion;
                //***********************
                //End of BEEM Database
                //***********************
                case PATExample.RINGING:
                    this.Text = "Ringing In New Year";
                    this.TextBox_Description.Text = "This is a maze problem from Erich Friedman's Homepage http://www2.stetson.edu/~efriedma/holiday/2011/index.html. \n In a maze, start at 2011. By moving through the maze and doing any arithmetic operations you encounter, exit the maze with a result of 2012. You may pass through an operation several times, but not twice in a row.";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " pillar";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 12, 23)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                //***********************
                //Start of Security Protocol Module
                //***********************
                case PATExample.HandshakeProtocol:
                    this.Text = "Navie Handshake Protocol";
                    this.TextBox_Description.Text = "";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " pillar";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 06, 07)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.NeedhamSchroederPK:
                    this.Text = "Needham Schroeder Public Key Protocol";
                    this.TextBox_Description.Text = "";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " pillar";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 06, 07)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.OtwayReesProtocol:
                    this.Text = "OtwayRees Protocol";
                    this.TextBox_Description.Text = "";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " pillar";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 06, 07)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.EKEProtocol:
                    this.Text = "EKE Protocol";
                    this.TextBox_Description.Text = "";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " pillar";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 06, 07)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.VoteProtocol:
                    this.Text = "Vote Protocol";
                    this.TextBox_Description.Text = "";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " pillar";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2011, 06, 07)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                //***********************
                //End of Security Protocol Module
                //***********************
                case PATExample.InputOutput:
                    this.Text = "Input and Output";
                    this.TextBox_Description.Text = "Almost every paper for comositional verification use this as example.";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Leo Ji";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 07, 11)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.NUP_Number.Visible = false;
                    this.Label_To.Visible = false;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    break;
                case PATExample.ServerClient:
                    this.Text = "Server and Client";
                    this.TextBox_Description.Text = "This is an untimed version of the server and client example";

                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Leo Ji";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 07, 15)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.Label_To.Text = "Number of Client";
                    this.toolTip1.SetToolTip(Label_To, "Number of Client");
                    this.NUP_Number.Value = 5;
                    this.NUP_Number.Minimum = 1;
                    this.NUP_Number.Maximum = 50;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    break;

                    /****Added By Wang Ting***/
                case PATExample.BoxSorterUnit:
                    this.Text = "Box Sorter Unit";
                    this.TextBox_Description.Text = "This is an example from the paper 'UPPAAL in a Nutshell'.";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Wang Ting";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 08, 27)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    break;

                case PATExample.TwoDoors:
                    this.Text = "Two Doors";
                    this.TextBox_Description.Text = "A room has two doors which can not be open at the same time. A door starts to open if its button is pushed. The door opens for six seconds, thereafter it stays open for at least four seconds, but no more than eight seconds. The door takes six seconds to close and it stays closed for at least five seconds.";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Wang Ting";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 08, 27)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    break;

                case PATExample.Lynch_mahata:
                    this.Text = "Lynch_mahata";
                    this.TextBox_Description.Text = "In the original Fischer’s algorithm, two numeral parameters A, B guarantee its correctness provided that B > A. On the contrary, Lynch-Shavit’s algorithm does not depend on constraints on the parameters A and B in order to guarantee the mutual exclusion property. Yet it does rely on them in order to ensure some sort of deadlock freedom. The key point is to add a Boolean variable v2 in order to check whether the value of another process wishing to enter the critical region was overwritten.";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Wang Ting";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 08, 27)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Text = "The number of processes";
                    this.toolTip1.SetToolTip(Label_To, "The number of processes");
                    this.NUP_Number.Value = 4;
                    this.NUP_Number.Minimum = 4;
                    this.NUP_Number.Maximum = 100;
                    this.CheckBox_BDDSpecific.Visible = true;
                    break;

                case PATExample.TTAProtocal:
                    this.Text = "TTA Protocal";
                    this.TextBox_Description.Text = "The Time Triggered Architecture (TTA) enables distributed components to communicate in a fault-tolerant safety-critical way; it is employed in control units of cars and aircrafts. A TTA system is composed of host computers (the nodes) connected over a shared bus. Because many nodes share the bus, a time slot of equal duration is assigned to them, so that each node has to await for its turn in order to transmit - this is called a ’time-division multiple-access strategy’ (TDMA). Moreover, since no global clock signal exists in the system, each node relies only on its local clock in order to know when its turn starts. The goal of the start-up protocol is to synchronize local clocks so that each clock agrees with the others on the owner of the current slot. The basic idea of the protocol is that, when a node receives a packet (carrying the sender’s identity in the global variable origin), it knows the position of the TDMA schedule for the current time and consequently can appropriately set its clock (the local variable c). From this event, a new transmission is going to start every interval with duration equal to the slot time.";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Wang Ting";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 08, 27)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Text = "The number of nodes";
                    this.toolTip1.SetToolTip(Label_To, "The number of nodes");
                    this.NUP_Number.Value = 5;
                    this.NUP_Number.Minimum = 5;
                    this.NUP_Number.Maximum = 100;
                    this.CheckBox_BDDSpecific.Visible = false;
                    break;

                    /****Added By Wang Ting***/

                case PATExample.PV_FACEBOOK_CONNECT_SAMPLE:
                    this.Text = "Sample";
                    this.TextBox_Description.Text = "A Facebook Connect Protocol for Proverif models";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Li Li";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 08, 28)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    break;


                case PATExample.PV_SIM_DENNING_SACCO_SAMPLE:
                    this.Text = "Sample";
                    this.TextBox_Description.Text = "A Simpified Denning Sacco Protocol for Proverif models";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Li Li";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 08, 28)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    break;

                case PATExample.PV_DENNING_SACCO_SAMPLE:
                    this.Text = "Sample";
                    this.TextBox_Description.Text = "A Denning Sacco Protocol for Proverif models";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Li Li";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 08, 28)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    break;

                case PATExample.PV_DIFFIE_HELLMAN_SAMPLE:
                    this.Text = "Sample";
                    this.TextBox_Description.Text = "A Diffie Hellman Protocol for Proverif models";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Li Li";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 08, 28)).ToShortDateString();
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    break;
//UML models
                case PATExample.SimpleATMExample:
                    this.Text = "Sample";
                    this.TextBox_Description.Text = "A simple Automated Teller Machine(ATM) top level state machine example. The detailed description can be found at http://www.uml-diagrams.org/examples/bank-atm-example.html";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Liu Shuang";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 10, 21).ToShortDateString());
                    this.Label_CreatedBy.Tag = true;
                     this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    break;

                //case PATExample.ATMExample:
                //    this.Text = "Sample";
                //    this.TextBox_Description.Text = "An Automated Teller Machine(ATM) example focusing on the operation functionalities of an ATM machine.The detailed description can be found in paper \"UML Automatic Verification Tool with Formal Methods\".";
                //    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Liu Shuang";
                //    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 10, 28).ToShortDateString());
                //    this.Label_CreatedBy.Tag = true;
                //    this.CheckBox_HasThink.Visible = false;
                //    this.Panel_FairType.Visible = false;
                //    this.Panel_EventType.Visible = false;
                //    this.RadioButton_WL.Visible = false;
                //    this.RadioButton_SL.Visible = false;
                //    this.CheckBox_BDDSpecific.Visible = false;
                //    this.GroupBox_Options.Visible = false;
                //    this.Label_To.Visible = false;
                //    this.NUP_Number.Visible = false;
                //    break;

                case PATExample.BankATMExample:
                    this.Text = "Sample";
                    this.TextBox_Description.Text = "A UML state machine diagram which contains two state machines,"+
                        "i.e. Bank state machine and ATM state machine. They will interact with each other through"+ 
                        "message passing and call event. This example is taken from paper \"Model Checking and code"+
                        "generation for UML state machines and collaborations\" ";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Liu Shuang";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2012, 11, 22).ToShortDateString());
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    break;

                //case PATExample.BankATMwithVariablesExample:
                //    this.Text = "Sample";
                //    this.TextBox_Description.Text = "A UML state machine diagram which contains two state machines, i.e. Bank state machine and ATM state machine."+
                //                                                                        "They will interact with each other through message passing and call event.";
                //    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Liu Shuang";
                //    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2013, 1, 18).ToShortDateString());
                //    this.Label_CreatedBy.Tag = true;
                //    this.CheckBox_HasThink.Visible = false;
                //    this.Panel_FairType.Visible = false;
                //    this.Panel_EventType.Visible = false;
                //    this.RadioButton_WL.Visible = false;
                //    this.RadioButton_SL.Visible = false;
                //    this.CheckBox_BDDSpecific.Visible = false;
                //    this.GroupBox_Options.Visible = false;
                //    this.Label_To.Visible = false;
                //    this.NUP_Number.Visible = false;
                //    break;

                case PATExample.RailCarOriginalExample:
                    this.Text = "Sample";
                    this.TextBox_Description.Text = "This example is from paper \"Executable Object Modeling with StateCharts\" by David Harel and Eran Gery. "+
                                                                                     "The original model is object-oriented. We modified the original model to an non-OO vertion with UML state machines.";                                                                   ;
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Liu Shuang";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2013, 2, 17).ToShortDateString());
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    break;

                case PATExample.RailCarModifiedExample:
                    this.Text = "Sample";
                    this.TextBox_Description.Text = "This example is a modified version of the example in paper \"Executable Object Modeling with StateCharts\" by David Harel and Eran Gery. " +
                                                                                     "The original model is object-oriented. We modified the original model to an non-OO vertion with UML state machines." +
                                                                                     "The modified model is available @ http://www.comp.nus.edu.sg/~lius87/uml/casestudy/RailCar.pdf";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Liu Shuang";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2013, 4, 4).ToShortDateString());
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    break;

                case PATExample.TollGateExample:
                    this.Text = "Sample";
                    this.TextBox_Description.Text = "This example is from paper \"Specifying behavior semantics of UML diagrams through graphical transformations\" Kong et. al. " +
                                                                                     "We did modification on the car state machine and make it an non-OO version UML state machine diagram." +
                                                                                     "The modified model is available @ http://www.comp.nus.edu.sg/~lius87/uml/casestudy/TollGate.pdf";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Liu Shuang";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2013, 3, 11).ToShortDateString());
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    break;

                //case PATExample.DiningPhilosopherUML2SynchExample:
                //    this.Text = "Sample";
                //    this.TextBox_Description.Text = "This example is the calssical Dining philosopher problem with 2 philosophers. We use UML state machine to model the problem." +
                //                                    "The model is available @ http://www.comp.nus.edu.sg/~lius87/uml/casestudy/Phi_Synch_2.pdf";
                //    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Liu Shuang";
                //    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2013, 3, 11).ToShortDateString());
                //    this.Label_CreatedBy.Tag = true;
                //    this.CheckBox_HasThink.Visible = false;
                //    this.Panel_FairType.Visible = false;
                //    this.Panel_EventType.Visible = false;
                //    this.RadioButton_WL.Visible = false;
                //    this.RadioButton_SL.Visible = false;
                //    this.CheckBox_BDDSpecific.Visible = false;
                //    this.GroupBox_Options.Visible = false;
                //    this.Label_To.Visible = false;
                //    this.NUP_Number.Visible = false;
                //    break;

                case PATExample.DiningPhilosopherUML2Example:
                    this.Text = "Sample";
                    this.TextBox_Description.Text = "This example is the calssical Dining philosopher problem with 2 philosophers. We use UML state machine to model the problem." +
                                                    "The model is available @ http://www.comp.nus.edu.sg/~lius87/uml/casestudy/Phi_2.pdf";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Liu Shuang";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2013, 3, 11).ToShortDateString());
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    break;

                case PATExample.DiningPhilosopherUML3Example:
                    this.Text = "Sample";
                    this.TextBox_Description.Text = "This example is the calssical Dining philosopher problem with 3 philosophers. We use UML state machine to model the problem." +
                        "The way this example is modeled is similar to the example of 2 philosophers";                                                    
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Liu Shuang";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2013, 4, 4).ToShortDateString());
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    break;

                case PATExample.DiningPhilosopherUML4Example:
                    this.Text = "Sample";
                    this.TextBox_Description.Text = "This example is the calssical Dining philosopher problem with 4 philosophers. We use UML state machine to model the problem." +
                        "The way this example is modeled is similar to the example of 2 philosophers";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Liu Shuang";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2013, 4, 4).ToShortDateString());
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    break;

                case PATExample.DiningPhilosopherUML5Example:
                    this.Text = "Sample";
                    this.TextBox_Description.Text = "This example is the calssical Dining philosopher problem with 5 philosophers. We use UML state machine to model the problem." +
                        "The way this example is modeled is similar to the example of 2 philosophers";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Liu Shuang";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2013, 4, 4).ToShortDateString());
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    break;

                case PATExample.DiningPhilosopherUML6Example:
                    this.Text = "Sample";
                    this.TextBox_Description.Text = "This example is the calssical Dining philosopher problem with 6 philosophers. We use UML state machine to model the problem." +
                        "The way this example is modeled is similar to the example of 2 philosophers";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Liu Shuang";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2013, 4, 4).ToShortDateString());
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    break;

                case PATExample.DiningPhilosopherUML7Example:
                    this.Text = "Sample";
                    this.TextBox_Description.Text = "This example is the calssical Dining philosopher problem with 7 philosophers. We use UML state machine to model the problem." +
                        "The way this example is modeled is similar to the example of 2 philosophers";
                    this.Label_CreatedBy.Text = Label_CreatedBy.Text + " Liu Shuang";
                    this.Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2013, 4, 4).ToShortDateString());
                    this.Label_CreatedBy.Tag = true;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    this.GroupBox_Options.Visible = false;
                    this.Label_To.Visible = false;
                    this.NUP_Number.Visible = false;
                    break;

                case PATExample.NoDiscription:
                    this.Text = "Example";
                    this.TextBox_Description.Text = string.Empty;
                    this.CheckBox_HasThink.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.Panel_EventType.Visible = false;
                    this.RadioButton_WL.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.Label_To.Text = "The number of nodes";
                    this.toolTip1.SetToolTip(Label_To, "The number of processes");
                    this.NUP_Number.Value = 3;
                    this.NUP_Number.Minimum = 3;
                    this.NUP_Number.Maximum = 100;
                    this.CheckBox_BDDSpecific.Visible = false;
                    break;
                case PATExample.DinningPhilosophersCLTS:
                    this.Text = "Dinning Philosophers";
                    this.TextBox_Description.Text = "In 1971, Edsger Dijkstra set an examination question on a synchronization problem where five computers competed for access to five shared tape drive peripherals. Soon afterwards the problem was retold by Tony Hoare as the dining philosophers' problem. The problem is summarized as N philosophers sitting around a round table.\r\n\r\nThe five philosophers sit at a circular table with a large bowl of spaghetti in the center. A fork is placed in between each philosopher, and as such, each philosopher has one fork to his or her left and one fork to his or her right. As spaghetti is difficult to serve and eat with a single fork, it is assumed that a philosopher must eat with two forks. The philosopher can only use the fork on his or her immediate left or right. It is further assumed that the philosophers are so stubborn that a philosopher only put down the forks after eating.\r\n\r\nThere are several interesting problems. One is a dangerous possibility of deadlock when every philosopher holds a left fork and waits perpetually for a right fork. The other is starvation. A philosopher may starve for different reasons, e.g., system deadlock, greedy neighbor, etc.";
                    this.Panel_EventType.Visible = false;
                    this.Panel_FairType.Visible = false;
                    this.RadioButton_SL.Visible = false;
                    this.RadioButton_WL.Visible = false;


                    this.CheckBox_HasThink.Visible = false;
                    this.CheckBox_HasThink.Text = "Deadlock Free";
                    this.CheckBox_HasThink.Checked = false;
                    this.toolTip1.Active = false;
                    this.CheckBox_BDDSpecific.Visible = false;
                    break;
                default:
                    break;
            }

            if (Label_CreatedBy.Tag == null)
            {
                Label_CreatedBy.Text = Label_CreatedBy.Text + " PAT Team";
                Label_CreatedAt.Text = Label_CreatedAt.Text + " " + (new DateTime(2009, 9, 18)).ToShortDateString();
            }

        }

        private void RadioButton_WL_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_WL.Checked)
            {
                Panel_FairType.Enabled = true;
                Panel_EventType.Enabled = true;
            }
            else
            {
                Panel_FairType.Enabled = false;
                Panel_EventType.Enabled = false;
            }
        }

        //Added by pillar@2012/1/8
        private void NUP_Number_ValueChanged(object sender, EventArgs e)
        {
            this.NUP_Size.Value = (decimal)Math.Ceiling(Math.Log10((double)this.NUP_Number.Value) / Math.Log10(2)) + 1;
            if (this.NUP_Third.Visible == true && this.NUP_Third.Value != 0) this.NUP_Size.Value = 6;
        }
        //Added by pillar@2012/02/16
        private void NUP_Number_ValueChanged2(object sender, EventArgs e)
        {
            this.NUP_Size.Value = (decimal)Math.Ceiling(Math.Log10((double)this.NUP_Number.Value) / Math.Log10(2)) + 2;
            if (this.NUP_Third.Visible == true && this.NUP_Third.Value != 0) this.NUP_Size.Value = 6;
        }


        public bool IsDiningPhylospherDeadlockFree()
        {
            return CheckBox_HasThink.Checked;
        }

        private void GroupBox_Options_Enter(object sender, EventArgs e)
        {

        }

        private void CheckBox_HasThink_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Label_To_Click(object sender, EventArgs e)
        {

        }

    }
}
