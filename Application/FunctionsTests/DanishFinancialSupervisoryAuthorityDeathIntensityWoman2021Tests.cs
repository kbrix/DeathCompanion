using Functions;
using NUnit.Framework;

namespace FunctionsTests;

public class DanishFinancialSupervisoryAuthorityDeathIntensityWoman2021Tests
{
    [Test]
    public void DanishFinancialSupervisoryAuthorityDeathIntensityWoman2021_Example_ReturnsIntensity()
    {
        // Arrange
        var age = 50;
        var birthDate = new DateTime(1991, 01, 01);
        var intensity = new DanishFinancialSupervisoryAuthorityDeathIntensityWoman2021(birthDate);
        // Act
        var value = intensity.Evaluate(age);
        // Assert
        Assert.That(value, Is.EqualTo(0.000520).Within(0.000001));
    }

    [Test]
    public void DanishFinancialSupervisoryAuthorityDeathIntensityWoman2021_Ages_ReturnsIntensities()
    {
        // Arrange
        var birthDate = new DateTime(1991, 01, 01);
        var intensity = new DanishFinancialSupervisoryAuthorityDeathIntensityWoman2021(birthDate);
        var expectedValues = new[]
        {
            0.00014113164645456100, 0.00015589857814782596, 0.00017143175444459208, 0.00018101386762469488,
            0.00019262904708263249, 0.00021120852438715540, 0.00022285358453659175, 0.00024236795983807212,
            0.00026977008721543390, 0.00029562619833714270, 0.00031797145636422745, 0.00033675091685638520,
            0.00035409240520338080, 0.00036191896265171080, 0.00037259499708767960, 0.00038015583041676640,
            0.00038734801984003676, 0.00040023672285269680, 0.00042238993915349516, 0.00046372404660149544,
            0.00052039928423946840, 0.00059691128637970180, 0.00068161808248758820, 0.00076604880392553050,
            0.00087108174383887990, 0.00097994959341842070, 0.00112172604619426200, 0.00129468451270548850,
            0.00149894369161696500, 0.00170809897095929250, 0.00193760599114233320, 0.00217846324018356170,
            0.00239370562233324600, 0.00265994989111056340, 0.00291110545297668330, 0.00314289906359602360,
            0.00332104712558656400, 0.00341129135807300780, 0.00338808088827062000, 0.00330572637739997560,
            0.00323193068703344200, 0.00321138867565851900, 0.00330661619529009360, 0.00353824052356838200,
            0.00393544372211464700, 0.00449623675732245460, 0.00515909887114076600, 0.00609659494295525800,
            0.00716325697118181000, 0.00845488750125800300, 0.01008148552535000400, 0.01223066044439031500,
            0.01477786966295876300, 0.01829220811121636000, 0.02294678294148427500, 0.02876683204842891000,
            0.03551095099402024000, 0.04301650286527788000, 0.05100286810188126000, 0.05884746030050771000,
            0.06842399584731908000, 0.08029763796996572000, 0.09539491010776528000, 0.11337905668426396000,
            0.13503529259847777000, 0.15705419602930090000, 0.17960694419432124000, 0.20512142347986692000,
            0.23430513682210627000, 0.26956815546267865000, 0.31145698524778204000, 0.35997909870110790000,
            0.40960747044718143000, 0.45945011270619285000, 0.50965522365747150000, 0.55894819037220020000,
            0.60777776990501340000, 0.65534411228540680000, 0.69158556256708400000, 0.72410458534950200000,
            0.75432528407479600000
        };
        // Act
        var values = Enumerable
            .Range(2021 - 1991, 80 + 1)
            .Select(x => (Age: x, intensity: intensity.Evaluate(x)));
        // Assert
        CollectionAssert.AreEqual(values.Select(pair => pair.intensity), expectedValues);
    }

    [Test]
    public void DanishFinancialSupervisoryAuthorityDeathIntensityWoman2021_InvalidAge_ThrowsException()
    {
        // Arrange
        var x = 20;
        var birthDate = new DateTime(1991, 01, 01);
        var intensity = new DanishFinancialSupervisoryAuthorityDeathIntensityWoman2021(birthDate);
        // Act
        var action = (TestDelegate) (() => intensity.Evaluate(20));
        // Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(action);
        Assert.That(
            ex?.Message,
            Is.EqualTo(
                $"Mismatch between age '{x}' and birth date year '{birthDate.Year}'. " +
                $"The age must be >= {2021 - birthDate.Year}. (Parameter '{nameof(x)}')"));
    }
}