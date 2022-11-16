﻿namespace Functions;

/// <summary>
///     The Danish FSA's benchmark model for lifetime modelling for men 2021.
/// </summary>
public sealed class DanishFinancialSupervisoryAuthorityDeathIntensityMan2021
    : DanishFinancialSupervisoryAuthorityDeathIntensity
{
    private static readonly double[] Intensity =
    {
        0.00315618214894940000, 0.00018078399252916200, 0.00017120220168952000, 0.00012788774316088900,
        0.00010966007333524200, 0.00010568394828371000, 0.00010160359004371600, 0.00009888789299253840,
        0.00009511694869973030, 0.00009111271091757940, 0.00008327456121342910, 0.00007619204521194180,
        0.00007643983309019730, 0.00007516480204525070, 0.00008556755001012020, 0.00010753613561209600,
        0.00013879750814873500, 0.00018004492685368300, 0.00023210925948206900, 0.00027812154732263800,
        0.00032518428591260300, 0.00036903386272135600, 0.00040150396308697600, 0.00041986115984435700,
        0.00041924638513192600, 0.00040272451605239600, 0.00037017319506249800, 0.00033467692496730900,
        0.00031179872632195000, 0.00029764261998376400, 0.00028942986030152900, 0.00029156538569139600,
        0.00030209743927940200, 0.00031533362912128100, 0.00035577008798557700, 0.00040607895902093800,
        0.00044676289489711300, 0.00049526384304998100, 0.00053594700680173100, 0.00057841570442299700,
        0.00062851498954257800, 0.00070101856862993100, 0.00077716978314532700, 0.00085270355712908900,
        0.00093008161689750500, 0.00101303419109279000, 0.00111253666508408000, 0.00122109609369456000,
        0.00137617952549868000, 0.00153396520134268000, 0.00169972743907643000, 0.00189060762231970000,
        0.00209679829697818000, 0.00231736665021981000, 0.00257670898880461000, 0.00288704537185973000,
        0.00325913308904058000, 0.00370262015145924000, 0.00422142868078056000, 0.00479480913099440000,
        0.00543028855211971000, 0.00610618087677722000, 0.00687581083130458000, 0.00770005193853407000,
        0.00858235696648407000, 0.00946236929590167000, 0.01030498158396810000, 0.01116944778264770000,
        0.01207953388422990000, 0.01314063214410970000, 0.01445128361712840000, 0.01599591607745190000,
        0.01778041463094540000, 0.01992330607075160000, 0.02235909277748910000, 0.02483350317269680000,
        0.02761457705998690000, 0.03066448167493560000, 0.03422705280664110000, 0.03864712328091000000,
        0.04409917194563500000, 0.05043556108258730000, 0.05783066069316870000, 0.06666327473463700000,
        0.07620730280112820000, 0.08759160527302750000, 0.10100102548322700000, 0.11633729830315300000,
        0.13406867040039100000, 0.15446002698158700000, 0.17685610667307300000, 0.20145901780762800000,
        0.22857864661668300000, 0.25743094412234400000, 0.28849269032786300000, 0.32163765221651500000,
        0.35664902160859000000, 0.39323413771074700000, 0.43103625759612700000, 0.46964630464702300000,
        0.50861910534569200000, 0.54749287858935100000, 0.58581026589683900000, 0.62313895770699700000,
        0.65909003149585300000, 0.69333245847880400000, 0.72560278365221000000, 0.75570962616395000000,
        0.78511883344031200000, 0.81179115227128900000, 0.83564909605731300000
    };

    private static readonly double[] Improvement =
    {
        0.01664241909992650000, 0.03882172094660270000, 0.02990675106094050000, 0.06247259907229850000,
        0.05671657941586130000, 0.05691435217290560000, 0.06063265466895750000, 0.06675499549066630000,
        0.07143522486899740000, 0.07322893315928970000, 0.07245623166947010000, 0.07129827725672260000,
        0.06749040794916650000, 0.06686153114373670000, 0.06723994673268060000, 0.06867989964711170000,
        0.06581606242535930000, 0.06356965447645440000, 0.06009356004085690000, 0.05576231445104930000,
        0.05243174753764490000, 0.04792565189059990000, 0.04434968315046340000, 0.04160192024689450000,
        0.03953553387164140000, 0.03787738133091070000, 0.03642201669779980000, 0.03504584234167320000,
        0.03431449286993900000, 0.03414409815404540000, 0.03564678938048640000, 0.03705169760173450000,
        0.03785890399331960000, 0.03806640469965980000, 0.03695025515788360000, 0.03474752657567180000,
        0.03378884705414730000, 0.03395464133564500000, 0.03502223448807140000, 0.03711527420013630000,
        0.03930339376713000000, 0.04059245590040480000, 0.04140215950416520000, 0.04181680665619030000,
        0.04143904020451900000, 0.04071438139342750000, 0.03980946278664320000, 0.03902180093787760000,
        0.03828705064869270000, 0.03832349566858040000, 0.03859827899617340000, 0.03852283911464420000,
        0.03794177255242310000, 0.03647661811127090000, 0.03389008906015940000, 0.03099889738936590000,
        0.02838672049008010000, 0.02582585589881680000, 0.02403432855651080000, 0.02286273538817150000,
        0.02196391329624790000, 0.02122205459176720000, 0.02066343979323430000, 0.02012430345243970000,
        0.01988462405479450000, 0.01981285675636680000, 0.02008639084295740000, 0.02065863547990530000,
        0.02154310145227600000, 0.02268868216579430000, 0.02402463706162450000, 0.02526792615397750000,
        0.02636128486982810000, 0.02717271707958660000, 0.02761427990920270000, 0.02793331776647740000,
        0.02808475076086580000, 0.02810250567757540000, 0.02786570670249320000, 0.02737129761868790000,
        0.02641506507202690000, 0.02514101354600080000, 0.02366842589029060000, 0.02207006052526820000,
        0.02022192122384400000, 0.01819302497631180000, 0.01614632130705930000, 0.01403405356484800000,
        0.01215013305767340000, 0.01069832325975300000, 0.00934816327299466000, 0.00808542569282412000,
        0.00689367541287838000, 0.00561633343353414000, 0.00426501196201590000, 0.00309129800607467000,
        0.00180616857927600000, 0.00054038134133078700, 0.00000000000000000000, 0.00000000000000000000,
        0.00000000000000000000, 0.00000000000000000000, 0.00000000000000000000, 0.00000000000000000000,
        0.00000000000000000000, 0.00000000000000000000, 0.00000000000000000000, 0.00000000000000000000,
        0.00000000000000000000, 0.00000000000000000000, 0.00000000000000000000
    };

    /// <summary>
    ///     Initializes a new instance of <see cref="DanishFinancialSupervisoryAuthorityDeathIntensityMan2021" />.
    /// </summary>
    /// <param name="birthDateYear">The year of birth of the man.</param>
    public DanishFinancialSupervisoryAuthorityDeathIntensityMan2021(int birthDateYear)
        : base(Intensity, Improvement, birthDateYear, 2021)
    {
    }
}