namespace Projeto.Model.Exceptions;

public class RuleException(string ruleErrorMessage) : Exception(ruleErrorMessage);

