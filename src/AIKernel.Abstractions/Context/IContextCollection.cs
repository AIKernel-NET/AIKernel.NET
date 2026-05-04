namespace AIKernel.Abstractions.Context;

/// <summary>
/// �R���e�L�X�g���̏W�����Ǘ�����C���^�[�t�F�[�X�B
/// �J�e�S���ʂ̊u���Ɠǂݎ���p�A�N�Z�X��ۏ؂��܂��B
/// </summary>
public interface IContextCollection
{
    /// <summary>
    /// ���ׂẴR���e�L�X�g�t���O�����g���擾���܂��B
    /// </summary>
    /// <returns>�t���O�����g�ꗗ</returns>
    IEnumerable<ContextFragment> GetAll();

    /// <summary>
    /// �w�肳�ꂽ�J�e�S���ɑ�����t���O�����g���擾���܂��B
    /// </summary>
    /// <param name="category">�J�e�S��</param>
    /// <returns>�J�e�S���Ɉ�v����t���O�����g�ꗗ</returns>
    IEnumerable<ContextFragment> GetByCategory(ContextCategory category);

    /// <summary>
    /// Orchestration �o�b�t�@���擾���܂��B
    /// </summary>
    /// <returns>Orchestration �t�F�[�Y�p�o�b�t�@</returns>
    OrchestrationBuffer GetOrchestrationBuffer();

    /// <summary>
    /// Expression �o�b�t�@���擾���܂��B
    /// </summary>
    /// <returns>Expression �t�F�[�Y�p�o�b�t�@</returns>
    ExpressionBuffer GetExpressionBuffer();

    /// <summary>
    /// Material �o�b�t�@���擾���܂��B
    /// </summary>
    /// <returns>Material �t�F�[�Y�p�o�b�t�@</returns>
    MaterialBuffer GetMaterialBuffer();

    /// <summary>
    /// History �o�b�t�@���擾���܂��B
    /// </summary>
    /// <returns>History �t�F�[�Y�p�o�b�t�@</returns>
    HistoryBuffer GetHistoryBuffer();
}
