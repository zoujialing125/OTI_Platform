DECLARE @XmlFile XML

SELECT @XmlFile = BulkColumn
FROM  OPENROWSET(BULK 'C:\Users\jjz052\Desktop\Matrix xml\ClientTeamDpt.xml', SINGLE_BLOB) x;

SELECT * INTO ClientDetails FROM (
SELECT
    Client = Item.value('(Client)[1]', 'nvarchar(max)'),
    TLUID = Item.value('(TLUID)[1]', 'nvarchar(20)'),
    Team = Item.value('(Team)[1]', 'nvarchar(40)'),
    Dept = Item.value('(Dept)[1]', 'nvarchar(6)')
    --PreAsign = Item.value('(PreAsign)[1]', 'nvarchar(1)'),
    --OPSName = Item.value('(OPSName)[1]', 'nvarchar(20)'),
    --OPSTel = Item.value('(OPSTel)[1]', 'nvarchar(4)')
FROM
    @XmlFile.nodes('/RLMOM4L1/Item') AS XTbl(Item)) XMLSource